using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Response;

public class TickSize
{
    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("threshold")]
    public string Threshold { get; set; }
}
