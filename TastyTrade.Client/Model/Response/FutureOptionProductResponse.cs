using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Response;

public class FutureOptionProductResponse
{
    [JsonPropertyName("data")]
    public FutureOptionProduct Product { get; set; }

    [JsonPropertyName("context")]
    public string Context { get; set; }
}