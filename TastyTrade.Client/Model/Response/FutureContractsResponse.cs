using System.Collections.Generic;
using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class FutureContractsResponse
{
    [JsonProperty("data")]
    public FuturesData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}

public class FuturesData
{
    [JsonProperty("items")]
    public List<FutureContract> Items { get; set; }
}
