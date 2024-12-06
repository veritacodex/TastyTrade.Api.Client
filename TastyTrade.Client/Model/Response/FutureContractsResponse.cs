using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Response;

public class FutureContractsResponse
{
    [JsonPropertyName("data")]
    public FuturesData Data { get; set; }

    [JsonPropertyName("context")]
    public string Context { get; set; }
}

public class FuturesData
{
    [JsonPropertyName("items")]
    public List<FutureContract> Items { get; set; }
}
