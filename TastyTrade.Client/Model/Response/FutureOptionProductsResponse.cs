using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Response;

public class FutureOptionProductsResponse
{
    [JsonPropertyName("data")]
    public FutureOptionProductsResponseData Data { get; set; }

    [JsonPropertyName("context")]
    public string Context { get; set; }
}

public class FutureOptionProductsResponseData
{
    [JsonPropertyName("items")]
    public List<FutureOptionProduct> Items { get; set; }
}
