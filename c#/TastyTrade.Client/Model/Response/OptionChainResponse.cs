using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class OptionChainResponse
{
    [JsonProperty("data")]
    public OptionChainResponseData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}

public class OptionChainResponseData
{
    [JsonProperty("items")]
    public List<OptionChainResponseDataItem> Items { get; set; }
}

public class OptionChainResponseDataItem
{
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("instrument-type")]
    public string InstrumentType { get; set; }

    [JsonProperty("active")]
    public bool Active { get; set; }

    [JsonProperty("strike-price")]
    public string StrikePrice { get; set; }

    [JsonProperty("root-symbol")]
    public string RootSymbol { get; set; }

    [JsonProperty("underlying-symbol")]
    public string UnderlyingSymbol { get; set; }

    [JsonProperty("expiration-date")]
    public string ExpirationDate { get; set; }

    [JsonProperty("exercise-style")]
    public string ExerciseStyle { get; set; }

    [JsonProperty("shares-per-contract")]
    public int SharesPerContract { get; set; }

    [JsonProperty("option-type")]
    public string OptionType { get; set; }

    [JsonProperty("option-chain-type")]
    public string OptionChainType { get; set; }

    [JsonProperty("expiration-type")]
    public string ExpirationType { get; set; }

    [JsonProperty("settlement-type")]
    public string SettlementType { get; set; }

    [JsonProperty("stops-trading-at")]
    public DateTime StopsTradingAt { get; set; }

    [JsonProperty("market-time-instrument-collection")]
    public string MarketTimeInstrumentCollection { get; set; }

    [JsonProperty("days-to-expiration")]
    public int DaysToExpiration { get; set; }

    [JsonProperty("expires-at")]
    public DateTime ExpiresAt { get; set; }

    [JsonProperty("is-closing-only")]
    public bool IsClosingOnly { get; set; }

    [JsonProperty("streamer-symbol")]
    public string StreamerSymbol { get; set; }
}
