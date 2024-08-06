using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class FutureContractResponse
{
    [JsonProperty("data")]
    public FutureContract Contract { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}