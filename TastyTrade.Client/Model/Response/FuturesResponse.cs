using System.Collections.Generic;
using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class FuturesResponse
{
    [JsonProperty("data")]
    public FuturesData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}

public class FuturesData
{
    [JsonProperty("items")]
    public List<FuturesContract> Items { get; set; }
}
