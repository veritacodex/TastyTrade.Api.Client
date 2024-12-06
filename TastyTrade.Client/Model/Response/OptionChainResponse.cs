using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Response;

public class OptionChainResponse
{
    [JsonPropertyName("data")]
    public OptionChainResponseData Data { get; set; }

    [JsonPropertyName("context")]
    public string Context { get; set; }
}

public class OptionChainResponseData
{
    [JsonPropertyName("items")]
    public List<OptionChainResponseDataItem> Items { get; set; }
}

public class OptionChainResponseDataItem
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("instrument-type")]
    public string InstrumentType { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("strike-price")]
    public double StrikePrice { get; set; }

    [JsonPropertyName("root-symbol")]
    public string RootSymbol { get; set; }

    [JsonPropertyName("underlying-symbol")]
    public string UnderlyingSymbol { get; set; }

    [JsonPropertyName("expiration-date")]
    public string ExpirationDate { get; set; }

    [JsonPropertyName("exercise-style")]
    public string ExerciseStyle { get; set; }

    [JsonPropertyName("shares-per-contract")]
    public int SharesPerContract { get; set; }

    [JsonPropertyName("option-type")]
    public string OptionType { get; set; }

    [JsonPropertyName("option-chain-type")]
    public string OptionChainType { get; set; }

    [JsonPropertyName("expiration-type")]
    public string ExpirationType { get; set; }

    [JsonPropertyName("settlement-type")]
    public string SettlementType { get; set; }

    [JsonPropertyName("stops-trading-at")]
    public DateTime StopsTradingAt { get; set; }

    [JsonPropertyName("market-time-instrument-collection")]
    public string MarketTimeInstrumentCollection { get; set; }

    [JsonPropertyName("days-to-expiration")]
    public int DaysToExpiration { get; set; }

    [JsonPropertyName("expires-at")]
    public DateTime ExpiresAt { get; set; }

    [JsonPropertyName("is-closing-only")]
    public bool IsClosingOnly { get; set; }

    [JsonPropertyName("streamer-symbol")]
    public string StreamerSymbol { get; set; }
}
