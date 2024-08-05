using System;
using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class TradingStatusResponse
{
    [JsonProperty("data")]
    public TradingStatusData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}

public class TradingStatusData
{
    [JsonProperty("account-number")]
    public string AccountNumber { get; set; }

    [JsonProperty("equities-margin-calculation-type")]
    public string EquitiesMarginCalculationType { get; set; }

    [JsonProperty("fee-schedule-name")]
    public string FeeScheduleName { get; set; }

    [JsonProperty("futures-margin-rate-multiplier")]
    public string FuturesMarginRateMultiplier { get; set; }

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("are-deep-itm-carry-options-enabled")]
    public bool AreDeepItmCarryOptionsEnabled { get; set; }

    [JsonProperty("are-far-otm-net-options-restricted")]
    public bool AreFarOtmNetOptionsRestricted { get; set; }

    [JsonProperty("are-options-values-restricted-to-nlv")]
    public bool AreOptionsValuesRestrictedToNlv { get; set; }

    [JsonProperty("are-single-tick-expiring-hedges-ignored")]
    public bool AreSingleTickExpiringHedgesIgnored { get; set; }

    [JsonProperty("has-intraday-equities-margin")]
    public bool HasIntradayEquitiesMargin { get; set; }

    [JsonProperty("is-aggregated-at-clearing")]
    public bool IsAggregatedAtClearing { get; set; }

    [JsonProperty("is-closed")]
    public bool IsClosed { get; set; }

    [JsonProperty("is-closing-only")]
    public bool IsClosingOnly { get; set; }

    [JsonProperty("is-cryptocurrency-closing-only")]
    public bool IsCryptocurrencyClosingOnly { get; set; }

    [JsonProperty("is-cryptocurrency-enabled")]
    public bool IsCryptocurrencyEnabled { get; set; }

    [JsonProperty("is-equity-offering-closing-only")]
    public bool IsEquityOfferingClosingOnly { get; set; }

    [JsonProperty("is-equity-offering-enabled")]
    public bool IsEquityOfferingEnabled { get; set; }

    [JsonProperty("is-frozen")]
    public bool IsFrozen { get; set; }

    [JsonProperty("is-full-equity-margin-required")]
    public bool IsFullEquityMarginRequired { get; set; }

    [JsonProperty("is-futures-closing-only")]
    public bool IsFuturesClosingOnly { get; set; }

    [JsonProperty("is-futures-enabled")]
    public bool IsFuturesEnabled { get; set; }

    [JsonProperty("is-futures-intra-day-enabled")]
    public bool IsFuturesIntraDayEnabled { get; set; }

    [JsonProperty("is-in-day-trade-equity-maintenance-call")]
    public bool IsInDayTradeEquityMaintenanceCall { get; set; }

    [JsonProperty("is-in-margin-call")]
    public bool IsInMarginCall { get; set; }

    [JsonProperty("is-pattern-day-trader")]
    public bool IsPatternDayTrader { get; set; }

    [JsonProperty("is-portfolio-margin-enabled")]
    public bool IsPortfolioMarginEnabled { get; set; }

    [JsonProperty("is-risk-reducing-only")]
    public bool IsRiskReducingOnly { get; set; }

    [JsonProperty("is-roll-the-day-forward-enabled")]
    public bool IsRollTheDayForwardEnabled { get; set; }

    [JsonProperty("is-small-notional-futures-intra-day-enabled")]
    public bool IsSmallNotionalFuturesIntraDayEnabled { get; set; }

    [JsonProperty("short-calls-enabled")]
    public bool ShortCallsEnabled { get; set; }

    [JsonProperty("options-level")]
    public string OptionsLevel { get; set; }

    [JsonProperty("small-notional-futures-margin-rate-multiplier")]
    public string SmallNotionalFuturesMarginRateMultiplier { get; set; }

    [JsonProperty("enhanced-fraud-safeguards-enabled-at")]
    public DateTimeOffset EnhancedFraudSafeguardsEnabledAt { get; set; }

    [JsonProperty("updated-at")]
    public DateTimeOffset UpdatedAt { get; set; }
}
