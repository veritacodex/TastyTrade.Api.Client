using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Response;

public class FutureOptionProduct
{
    [JsonPropertyName("root-symbol")]
    public string RootSymbol { get; set; }

    [JsonPropertyName("cash-settled")]
    public bool CashSettled { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("clearing-code")]
    public string ClearingCode { get; set; }

    [JsonPropertyName("clearing-exchange-code")]
    public string ClearingExchangeCode { get; set; }

    [JsonPropertyName("clearing-price-multiplier")]
    public string ClearingPriceMultiplier { get; set; }

    [JsonPropertyName("display-factor")]
    public string DisplayFactor { get; set; }

    [JsonPropertyName("exchange")]
    public string Exchange { get; set; }

    [JsonPropertyName("product-type")]
    public string ProductType { get; set; }

    [JsonPropertyName("expiration-type")]
    public string ExpirationType { get; set; }

    [JsonPropertyName("settlement-delay-days")]
    public int SettlementDelayDays { get; set; }

    [JsonPropertyName("is-rollover")]
    public bool IsRollover { get; set; }

    [JsonPropertyName("market-sector")]
    public string MarketSector { get; set; }

    [JsonPropertyName("supported")]
    public bool Supported { get; set; }

    [JsonPropertyName("future-product")]
    public FutureProduct FutureProduct { get; set; }

    [JsonPropertyName("futures-trading-cutoff-times")]
    public List<FuturesTradingCutoffTime> FuturesTradingCutoffTimes { get; set; }

    [JsonPropertyName("legacy-code")]
    public string LegacyCode { get; set; }

    [JsonPropertyName("clearport-code")]
    public string ClearportCode { get; set; }
}

public class FuturesTradingCutoffTime
{
    [JsonPropertyName("timezone")]
    public string Timezone { get; set; }

    [JsonPropertyName("offset-seconds")]
    public int OffsetSeconds { get; set; }

    [JsonPropertyName("timing")]
    public string Timing { get; set; }
}
