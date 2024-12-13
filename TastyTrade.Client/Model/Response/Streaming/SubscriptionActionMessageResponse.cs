using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TastyTrade.Client.Model.Request.Streaming;

namespace TastyTrade.Client.Model.Response.Streaming
{
    public enum SubscriptionActionStatus {
        [JsonStringEnumMemberName("ok")]
        OK = 0,
        [JsonStringEnumMemberName("error")]
        Error = 1 


    }
    public class SubscriptionActionMessageResponse<T> where T : class
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("status")] // one of the available actions below
        public SubscriptionActionStatus Status { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("action")] // one of the available actions below
        public SubscriptionActionType Action { get; set; }

        [JsonPropertyName("web-socket-session-id")]
        public string WebSocketSessionId { get; set; }

        [JsonPropertyName("value")] // Optional. Depends on the message action being sent (see available actions below)
        public T[] Value { get; set; }

        [JsonPropertyName("auth-token")] // `session-token` value from session creation response
        public string AuthToken { get; set; }

        [JsonPropertyName("request-id")]
        public long RequestId { get; set; }
    }
}
