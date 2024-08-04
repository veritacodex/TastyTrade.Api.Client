using System;
using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class FuturesContractResponse
{
    [JsonProperty("data")]
    public FuturesContract Contract { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}