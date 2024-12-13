
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using TastyTrade.Client.Model.Request;
using TastyTrade.Client.Model.Request.Streaming;
using TastyTrade.Client.Model.Response.Streaming;
using TastyTrade.Client.Model.Helper;
using TastyTrade.Client.Utils;

namespace TastyTrade.Client.Examples
{
    public static class AccountStreamer
    {
        private static long _heartbeatIntervalMillis = 6000L;
        private static AccountDataUpdates _accountUpdates;
        private static long _requestId = 2L;
        private static readonly string _StreamingAccountOrderUpdate_Type = nameof(StreamingAccountOrderUpdate.Type);
        private static readonly string _SubscriptionActionMessageResponse_Action = nameof(SubscriptionActionMessageResponse<string>.Action);
        private static readonly Dictionary<SubscriptionActionType, string> _actionTypeStringMap = new Dictionary<SubscriptionActionType, string>();
        private static readonly Dictionary<StreamingAccountUpdateType, string> _accountUpdateTypeStringMap = new Dictionary<StreamingAccountUpdateType, string>();
        private static readonly Dictionary<string, string> _accountUpdateKeySerializationPropertyNameMap = new Dictionary<string, string>();

        public static void SetupSerializationAttributeStringMaps()
        {
            var actionTypeEnumType = typeof(SubscriptionActionType);

            //map SubscriptionActionType.Connect -> connect
            var connectMemberInfos = actionTypeEnumType.GetMember(SubscriptionActionType.Connect.ToString());
            var connectEnumValueMemberInfo = connectMemberInfos.FirstOrDefault(m =>
            m.DeclaringType == actionTypeEnumType);
            Guard.NotNull(connectEnumValueMemberInfo, nameof(connectEnumValueMemberInfo)); 
            var connectValueAttributes = connectEnumValueMemberInfo.GetCustomAttributes(typeof(JsonStringEnumMemberNameAttribute), false);
            var connectSerializationValue = ((JsonStringEnumMemberNameAttribute)connectValueAttributes[0]).Name;
            _actionTypeStringMap.Add(SubscriptionActionType.Connect, connectSerializationValue);

            //map SubscriptionActionType.Heartbeat -> heartbeat
            var heartbeatMemberInfos = actionTypeEnumType.GetMember(SubscriptionActionType.Heartbeat.ToString());
            var heartbeatEnumValueMemberInfo = heartbeatMemberInfos.FirstOrDefault(m =>
            m.DeclaringType == actionTypeEnumType);
            Guard.NotNull(heartbeatEnumValueMemberInfo, nameof(heartbeatEnumValueMemberInfo)); 
            var heartbeatValueAttributes = heartbeatEnumValueMemberInfo.GetCustomAttributes(typeof(JsonStringEnumMemberNameAttribute), false);
            var heartbeatSerializationValue = ((JsonStringEnumMemberNameAttribute)heartbeatValueAttributes[0]).Name;
            _actionTypeStringMap.Add(SubscriptionActionType.Heartbeat, heartbeatSerializationValue);

            var acctUpdateTypeEnumType = typeof(StreamingAccountUpdateType);

            //map StreamingAccountUpdateType.Order -> Order
            var orderMemberInfos = acctUpdateTypeEnumType.GetMember(StreamingAccountUpdateType.Order.ToString());
            var orderEnumValueMemberInfo = orderMemberInfos.FirstOrDefault(m =>
            m.DeclaringType == acctUpdateTypeEnumType);
            Guard.NotNull(orderEnumValueMemberInfo, nameof(orderEnumValueMemberInfo));
            var orderValueAttributes = orderEnumValueMemberInfo.GetCustomAttributes(typeof(JsonStringEnumMemberNameAttribute), false);
            var orderSerializationValue = ((JsonStringEnumMemberNameAttribute)orderValueAttributes[0]).Name;
            _accountUpdateTypeStringMap.Add(StreamingAccountUpdateType.Order, orderSerializationValue);

            //map message response type keys
            //StreamingAccountOrderUpdate
            var streamingAccountOrderUpdateType = typeof(StreamingAccountOrderUpdate);
            var updateTypeMemberInfo = streamingAccountOrderUpdateType.GetMember(_StreamingAccountOrderUpdate_Type)[0];
            var updateTypeAttributes = updateTypeMemberInfo.GetCustomAttributes(typeof(JsonPropertyNameAttribute), false);
            var updateTypeSerializationValue = ((JsonPropertyNameAttribute)updateTypeAttributes[0]).Name;
            _accountUpdateKeySerializationPropertyNameMap.Add(_StreamingAccountOrderUpdate_Type, updateTypeSerializationValue);

            //SubscriptionActionMessageResponse<string>
            var actionMessageActionType = typeof(SubscriptionActionMessageResponse<string>);
            var actionMessageActionTypeMemberInfo = actionMessageActionType.GetMember(_SubscriptionActionMessageResponse_Action)[0];
            var actionMessageActionTypeAttributes = actionMessageActionTypeMemberInfo.GetCustomAttributes(typeof(JsonPropertyNameAttribute), false);
            var actionMessageActionTypeSerializationValue = ((JsonPropertyNameAttribute)actionMessageActionTypeAttributes[0]).Name;
            _accountUpdateKeySerializationPropertyNameMap.Add(_SubscriptionActionMessageResponse_Action, actionMessageActionTypeSerializationValue);
        }
        public static async Task Run()
        {
            _accountUpdates = new AccountDataUpdates();

            SetupSerializationAttributeStringMaps();
            var credentials = JsonSerializer.Deserialize<AuthorizationCredentials>(await File.ReadAllTextAsync(Program.CredsPath));
            var tastyTradeClient = new TastyTradeClient();
            await tastyTradeClient.Authenticate(credentials);

            var authToken = tastyTradeClient.GetAuthenticationResponse().Data.SessionToken;

            using var source = new CancellationTokenSource();
            using var ws = new ClientWebSocket();
            Stopwatch _heartbeatStopwatch = Stopwatch.StartNew();
            Timer heartbeatTimer = new Timer((s) =>
            {
                if (_accountUpdates.ConnectionStatus == AccountDataUpdatesConnectionStatus.Open
                && _heartbeatStopwatch.ElapsedMilliseconds >= _heartbeatIntervalMillis)
                {
                    _heartbeatStopwatch.Restart();
                    var heartbeatMsg = new SubscriptionActionMessageRequest<string>() { Action = SubscriptionActionType.Heartbeat, AuthToken = authToken, RequestId = _requestId++, Value = new string[] { credentials.AccountNumber } };
                    var heartbeatMsgBody = JsonSerializer.Serialize(heartbeatMsg);

                    ArraySegment<byte> heartBeatBytesToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(heartbeatMsgBody));
                    ws.SendAsync(heartBeatBytesToSend, WebSocketMessageType.Text, true, source.Token).GetAwaiter().GetResult();
                    Console.WriteLine($"heartbeat sent: {DateTime.UtcNow.ToString("yyyyMMddHHmmss")}");
                }
            }, null, _heartbeatIntervalMillis, _heartbeatIntervalMillis);

            await ws.ConnectAsync(new Uri(credentials.StreamingApiBaseUrl), CancellationToken.None);

            var connectMsg = new SubscriptionActionMessageRequest<string>() { Action = SubscriptionActionType.Connect, AuthToken = authToken, RequestId = _requestId++, Value = new string[] { credentials.AccountNumber } };
            var connectMsgBody = JsonSerializer.Serialize(connectMsg);

            ArraySegment<byte> bytesToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(connectMsgBody));
            await ws.SendAsync(bytesToSend, WebSocketMessageType.Text, true, source.Token);

            byte[] buffer = new byte[4096];

            while (ws.State == WebSocketState.Open && (_accountUpdates.ConnectionStatus != AccountDataUpdatesConnectionStatus.Fault))
            {
                // exec waits on receive here, so heartbeat has to be in a separate task or code won't fire heart beat until another update comes through which means socket will likley die in 10 to 15 seconds
                var result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                    _accountUpdates.ConnectionStatus = AccountDataUpdatesConnectionStatus.Closed;
                }
                else
                {
                    HandleMessage(buffer, result.Count);
                }
            }
            await heartbeatTimer.DisposeAsync();
            Console.WriteLine($"{nameof(AccountStreamer)} runloop exited: {DateTime.UtcNow:yyyyMMddHHmmss}");
        }

        private static void HandleMessage(byte[] buffer, int count)
        {
            var msgBody = UTF8Encoding.UTF8.GetString(buffer, 0, count);
            Console.WriteLine(msgBody);
            if (msgBody.Contains($"\"{_accountUpdateKeySerializationPropertyNameMap[_SubscriptionActionMessageResponse_Action]}\":\"{_actionTypeStringMap[SubscriptionActionType.Connect]}\""))
            {
                _accountUpdates.ConnectionStatus = AccountDataUpdatesConnectionStatus.Open;
                _accountUpdates.ConnectionOpened = DateTime.UtcNow;
                Console.WriteLine($"connect confirmation received: {DateTime.UtcNow:yyyyMMddHHmmss}");
            }
            else if (msgBody.Contains($"\"{_accountUpdateKeySerializationPropertyNameMap[_SubscriptionActionMessageResponse_Action]}\":\"{_actionTypeStringMap[SubscriptionActionType.Heartbeat]}\""))
            {
                _accountUpdates.LastHeartbeatReceived = DateTime.UtcNow;
                Console.WriteLine($"heartbeat received: {DateTime.UtcNow.ToString("yyyyMMddHHmmss")}");
            }
            else if (msgBody.Contains($"\"{_accountUpdateKeySerializationPropertyNameMap[_StreamingAccountOrderUpdate_Type]}\":\"{_accountUpdateTypeStringMap[StreamingAccountUpdateType.Order]}\""))
            {
                var orderUpdate = JsonSerializer.Deserialize<StreamingAccountOrderUpdate>(msgBody);
                _accountUpdates.OrderUpdates.Enqueue(orderUpdate);
                _accountUpdates.LastOrderUpdateReceived = DateTime.UtcNow;
                Console.WriteLine($"StreamingAccountOrderUpdate received: {DateTime.UtcNow.ToString("yyyyMMddHHmmss")}");
            }
            else
            {
                Console.WriteLine("unhandled message type");
            }
        }
    }
}
