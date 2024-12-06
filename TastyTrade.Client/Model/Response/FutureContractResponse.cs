using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Response;

public class FutureContractResponse
{
    [JsonPropertyName("data")]
    public FutureContract Contract { get; set; }

    [JsonPropertyName("context")]
    public string Context { get; set; }
}