using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class EquityResponse
{
    [JsonProperty("data")]
    public EquityResponseData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}

public class EquityResponseData
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("instrument-type")]
    public string InstrumentType { get; set; }

    [JsonProperty("cusip")]
    public string Cusip { get; set; }

    [JsonProperty("short-description")]
    public string ShortDescription { get; set; }

    [JsonProperty("is-index")]
    public bool IsIndex { get; set; }

    [JsonProperty("listed-market")]
    public string ListedMarket { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("lendability")]
    public string Lendability { get; set; }

    [JsonProperty("market-time-instrument-collection")]
    public string MarketTimeInstrumentCollection { get; set; }

    [JsonProperty("is-closing-only")]
    public bool IsClosingOnly { get; set; }

    [JsonProperty("is-options-closing-only")]
    public bool IsOptionsClosingOnly { get; set; }

    [JsonProperty("active")]
    public bool Active { get; set; }

    [JsonProperty("is-illiquid")]
    public bool IsIlliquid { get; set; }

    [JsonProperty("is-etf")]
    public bool IsEtf { get; set; }

    [JsonProperty("is-fraud-risk")]
    public bool IsFraudRisk { get; set; }

    [JsonProperty("streamer-symbol")]
    public string StreamerSymbol { get; set; }

    [JsonProperty("bypass-manual-review")]
    public bool BypassManualReview { get; set; }

    [JsonProperty("tick-sizes")]
    public TickSize[] TickSizes { get; set; }

    [JsonProperty("option-tick-sizes")]
    public TickSize[] OptionTickSizes { get; set; }
}
