using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class TransactionsResponse
{
    [JsonProperty("data")]
    public TransactionsResponseData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class TransactionsResponseData
{
    [JsonProperty("items")]
    public List<TransactionsResponseDataItem> Items { get; set; }
}

public class TransactionsResponseDataItem
{
    [JsonProperty("symbol")]
    public object Symbol { get; set; }

    [JsonProperty("instrument-type")]
    public object InstrumentType { get; set; }

    [JsonProperty("active")]
    public bool Active { get; set; }

    [JsonProperty("strike-price")]
    public object StrikePrice { get; set; }

    [JsonProperty("root-symbol")]
    public object RootSymbol { get; set; }

    [JsonProperty("underlying-symbol")]
    public object UnderlyingSymbol { get; set; }

    [JsonProperty("expiration-date")]
    public object ExpirationDate { get; set; }

    [JsonProperty("exercise-style")]
    public object ExerciseStyle { get; set; }

    [JsonProperty("shares-per-contract")]
    public int SharesPerContract { get; set; }

    [JsonProperty("option-type")]
    public object OptionType { get; set; }

    [JsonProperty("option-chain-type")]
    public object OptionChainType { get; set; }

    [JsonProperty("expiration-type")]
    public object ExpirationType { get; set; }

    [JsonProperty("settlement-type")]
    public object SettlementType { get; set; }

    [JsonProperty("stops-trading-at")]
    public DateTime StopsTradingAt { get; set; }

    [JsonProperty("market-time-instrument-collection")]
    public object MarketTimeInstrumentCollection { get; set; }

    [JsonProperty("days-to-expiration")]
    public int DaysToExpiration { get; set; }

    [JsonProperty("expires-at")]
    public DateTime ExpiresAt { get; set; }

    [JsonProperty("is-closing-only")]
    public bool IsClosingOnly { get; set; }

    [JsonProperty("streamer-symbol")]
    public object StreamerSymbol { get; set; }
}


