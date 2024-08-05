using System.Collections.Generic;
using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class FutureOptionProductsResponse
{
    [JsonProperty("data")]
    public FutureOptionProductsResponseData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}

public class FutureOptionProductsResponseData
{
    [JsonProperty("items")]
    public List<FutureOptionProduct> Items { get; set; }
}
