
using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class FutureOptionProductResponse
{
    [JsonProperty("data")]
    public FutureOptionProduct Product { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}