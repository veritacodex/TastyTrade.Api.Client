using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Response.Streaming
{
    public enum StreamingAccountUpdateType {
        [JsonStringEnumMemberName("Order")]
        Order = 0
    }
    public class StreamingAccountOrderUpdate
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("type")]
        public StreamingAccountUpdateType Type { get; set; }
        [JsonPropertyName("data")]
        public PlacedOrderReceipt Data { get; set; }
        [JsonPropertyName("timestamp")]
        public long Timestamp  { get; set; }
    }
}
