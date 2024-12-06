using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Response;

public class EquityResponse
{
    [JsonPropertyName("data")]
    public EquityResponseData Data { get; set; }

    [JsonPropertyName("context")]
    public string Context { get; set; }
}

public class EquityResponseData
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("instrument-type")]
    public string InstrumentType { get; set; }

    [JsonPropertyName("cusip")]
    public string Cusip { get; set; }

    [JsonPropertyName("short-description")]
    public string ShortDescription { get; set; }

    [JsonPropertyName("is-index")]
    public bool IsIndex { get; set; }

    [JsonPropertyName("listed-market")]
    public string ListedMarket { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("lendability")]
    public string Lendability { get; set; }

    [JsonPropertyName("market-time-instrument-collection")]
    public string MarketTimeInstrumentCollection { get; set; }

    [JsonPropertyName("is-closing-only")]
    public bool IsClosingOnly { get; set; }

    [JsonPropertyName("is-options-closing-only")]
    public bool IsOptionsClosingOnly { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("is-illiquid")]
    public bool IsIlliquid { get; set; }

    [JsonPropertyName("is-etf")]
    public bool IsEtf { get; set; }

    [JsonPropertyName("is-fraud-risk")]
    public bool IsFraudRisk { get; set; }

    [JsonPropertyName("streamer-symbol")]
    public string StreamerSymbol { get; set; }

    [JsonPropertyName("bypass-manual-review")]
    public bool BypassManualReview { get; set; }

    [JsonPropertyName("tick-sizes")]
    public TickSize[] TickSizes { get; set; }

    [JsonPropertyName("option-tick-sizes")]
    public TickSize[] OptionTickSizes { get; set; }
}
