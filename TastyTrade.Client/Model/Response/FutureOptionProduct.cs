using System.Collections.Generic;
using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class FutureOptionProduct
{
    [JsonProperty("root-symbol")]
    public string RootSymbol { get; set; }

    [JsonProperty("cash-settled")]
    public bool CashSettled { get; set; }

    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("clearing-code")]
    public string ClearingCode { get; set; }

    [JsonProperty("clearing-exchange-code")]
    public string ClearingExchangeCode { get; set; }

    [JsonProperty("clearing-price-multiplier")]
    public string ClearingPriceMultiplier { get; set; }

    [JsonProperty("display-factor")]
    public string DisplayFactor { get; set; }

    [JsonProperty("exchange")]
    public string Exchange { get; set; }

    [JsonProperty("product-type")]
    public string ProductType { get; set; }

    [JsonProperty("expiration-type")]
    public string ExpirationType { get; set; }

    [JsonProperty("settlement-delay-days")]
    public int SettlementDelayDays { get; set; }

    [JsonProperty("is-rollover")]
    public bool IsRollover { get; set; }

    [JsonProperty("market-sector")]
    public string MarketSector { get; set; }

    [JsonProperty("supported")]
    public bool Supported { get; set; }

    [JsonProperty("future-product")]
    public FutureProduct FutureProduct { get; set; }

    [JsonProperty("futures-trading-cutoff-times")]
    public List<FuturesTradingCutoffTime> FuturesTradingCutoffTimes { get; set; }

    [JsonProperty("legacy-code")]
    public string LegacyCode { get; set; }

    [JsonProperty("clearport-code")]
    public string ClearportCode { get; set; }
}

public class FuturesTradingCutoffTime
{
    [JsonProperty("timezone")]
    public string Timezone { get; set; }

    [JsonProperty("offset-seconds")]
    public int OffsetSeconds { get; set; }

    [JsonProperty("timing")]
    public string Timing { get; set; }
}
