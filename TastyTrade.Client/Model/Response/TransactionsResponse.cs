using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Response;

public class TransactionsResponse
{
    [JsonPropertyName("data")]
    public TransactionsResponseData Data { get; set; }

    [JsonPropertyName("context")]
    public string Context { get; set; }
}

public class TransactionsResponseData
{
    [JsonPropertyName("items")]
    public List<TransactionsResponseDataItem> Items { get; set; }
}

public class TransactionsResponseDataItem
{
    [JsonPropertyName("symbol")]
    public object Symbol { get; set; }

    [JsonPropertyName("instrument-type")]
    public object InstrumentType { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("strike-price")]
    public object StrikePrice { get; set; }

    [JsonPropertyName("root-symbol")]
    public object RootSymbol { get; set; }

    [JsonPropertyName("underlying-symbol")]
    public object UnderlyingSymbol { get; set; }

    [JsonPropertyName("expiration-date")]
    public object ExpirationDate { get; set; }

    [JsonPropertyName("exercise-style")]
    public object ExerciseStyle { get; set; }

    [JsonPropertyName("shares-per-contract")]
    public int SharesPerContract { get; set; }

    [JsonPropertyName("option-type")]
    public object OptionType { get; set; }

    [JsonPropertyName("option-chain-type")]
    public object OptionChainType { get; set; }

    [JsonPropertyName("expiration-type")]
    public object ExpirationType { get; set; }

    [JsonPropertyName("settlement-type")]
    public object SettlementType { get; set; }

    [JsonPropertyName("stops-trading-at")]
    public DateTime StopsTradingAt { get; set; }

    [JsonPropertyName("market-time-instrument-collection")]
    public object MarketTimeInstrumentCollection { get; set; }

    [JsonPropertyName("days-to-expiration")]
    public int DaysToExpiration { get; set; }

    [JsonPropertyName("expires-at")]
    public DateTime ExpiresAt { get; set; }

    [JsonPropertyName("is-closing-only")]
    public bool IsClosingOnly { get; set; }

    [JsonPropertyName("streamer-symbol")]
    public object StreamerSymbol { get; set; }
}


