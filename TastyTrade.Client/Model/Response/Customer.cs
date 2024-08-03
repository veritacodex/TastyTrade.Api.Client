using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class Customer
{
    [JsonProperty("data")]
    public CustomerData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}
