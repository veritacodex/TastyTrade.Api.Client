using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Request.Streaming
{
    public enum SubscriptionActionType
    {

        [JsonStringEnumMemberName("connect")]
        Connect = 0,
        [JsonStringEnumMemberName("heartbeat")]
        Heartbeat = 1,
        [JsonStringEnumMemberName("public-watchlists-subscribe")]
        PublicWatchlistsSubscribe = 2,
        [JsonStringEnumMemberName("quote-alerts-subscribe")]
        QuoteAlertsSubscribe = 3,
        [JsonStringEnumMemberName("user-message-subscribe")]
        UserMessageSubscribe = 4
    }

    public class SubscriptionActionMessageRequest<T>
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("action")] // one of the available actions below
        public SubscriptionActionType Action { get; set; }

        [JsonPropertyName("value")] // Optional. Depends on the message action being sent (see available actions below)
        public T[] Value { get; set; }

        [JsonPropertyName("auth-token")] // `session-token` value from session creation response
        public string AuthToken { get; set; }

        [JsonPropertyName("request-id")]
        public long RequestId { get; set; }
    }
}
