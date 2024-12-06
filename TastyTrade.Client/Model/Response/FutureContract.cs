using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Response;

public class FutureContract
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("product-code")]
    public string ProductCode { get; set; }

    [JsonPropertyName("contract-size")]
    public string ContractSize { get; set; }

    [JsonPropertyName("tick-size")]
    public string TickSize { get; set; }

    [JsonPropertyName("notional-multiplier")]
    public string NotionalMultiplier { get; set; }

    [JsonPropertyName("main-fraction")]
    public string MainFraction { get; set; }

    [JsonPropertyName("sub-fraction")]
    public string SubFraction { get; set; }

    [JsonPropertyName("display-factor")]
    public string DisplayFactor { get; set; }

    [JsonPropertyName("last-trade-date")]
    public string LastTradeDate { get; set; }

    [JsonPropertyName("expiration-date")]
    public string ExpirationDate { get; set; }

    [JsonPropertyName("closing-only-date")]
    public string ClosingOnlyDate { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("active-month")]
    public bool ActiveMonth { get; set; }

    [JsonPropertyName("next-active-month")]
    public bool NextActiveMonth { get; set; }

    [JsonPropertyName("is-closing-only")]
    public bool IsClosingOnly { get; set; }

    [JsonPropertyName("stops-trading-at")]
    public DateTime StopsTradingAt { get; set; }

    [JsonPropertyName("expires-at")]
    public DateTime ExpiresAt { get; set; }

    [JsonPropertyName("product-group")]
    public string ProductGroup { get; set; }

    [JsonPropertyName("exchange")]
    public string Exchange { get; set; }

    [JsonPropertyName("roll-target-symbol")]
    public string RollTargetSymbol { get; set; }

    [JsonPropertyName("streamer-exchange-code")]
    public string StreamerExchangeCode { get; set; }

    [JsonPropertyName("streamer-symbol")]
    public string StreamerSymbol { get; set; }

    [JsonPropertyName("back-month-first-calendar-symbol")]
    public bool BackMonthFirstCalendarSymbol { get; set; }

    [JsonPropertyName("is-tradeable")]
    public bool IsTradeable { get; set; }

    [JsonPropertyName("future-etf-equivalent")]
    public FutureEtfEquivalent FutureEtfEquivalent { get; set; }

    [JsonPropertyName("future-product")]
    public FutureProduct FutureProduct { get; set; }

    [JsonPropertyName("tick-sizes")]
    public List<TickSize> TickSizes { get; set; }

    [JsonPropertyName("option-tick-sizes")]
    public List<TickSize> OptionTickSizes { get; set; }

    [JsonPropertyName("spread-tick-sizes")]
    public List<SpreadTickSize> SpreadTickSizes { get; set; }

    [JsonPropertyName("first-notice-date")]
    public string FirstNoticeDate { get; set; }
}

public class FutureEtfEquivalent
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("share-quantity")]
    public int ShareQuantity { get; set; }
}

public class FutureProduct
{
    [JsonPropertyName("root-symbol")]
    public string RootSymbol { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("clearing-code")]
    public string ClearingCode { get; set; }

    [JsonPropertyName("clearing-exchange-code")]
    public string ClearingExchangeCode { get; set; }

    [JsonPropertyName("clearport-code")]
    public string ClearportCode { get; set; }

    [JsonPropertyName("legacy-code")]
    public string LegacyCode { get; set; }

    [JsonPropertyName("exchange")]
    public string Exchange { get; set; }

    [JsonPropertyName("legacy-exchange-code")]
    public string LegacyExchangeCode { get; set; }

    [JsonPropertyName("product-type")]
    public string ProductType { get; set; }

    [JsonPropertyName("listed-months")]
    public List<string> ListedMonths { get; set; }

    [JsonPropertyName("active-months")]
    public List<string> ActiveMonths { get; set; }

    [JsonPropertyName("notional-multiplier")]
    public string NotionalMultiplier { get; set; }

    [JsonPropertyName("tick-size")]
    public string TickSize { get; set; }

    [JsonPropertyName("display-factor")]
    public string DisplayFactor { get; set; }

    [JsonPropertyName("streamer-exchange-code")]
    public string StreamerExchangeCode { get; set; }

    [JsonPropertyName("small-notional")]
    public bool SmallNotional { get; set; }

    [JsonPropertyName("back-month-first-calendar-symbol")]
    public bool BackMonthFirstCalendarSymbol { get; set; }

    [JsonPropertyName("first-notice")]
    public bool FirstNotice { get; set; }

    [JsonPropertyName("cash-settled")]
    public bool CashSettled { get; set; }

    [JsonPropertyName("security-group")]
    public string SecurityGroup { get; set; }

    [JsonPropertyName("market-sector")]
    public string MarketSector { get; set; }

    [JsonPropertyName("roll")]
    public Roll Roll { get; set; }

    [JsonPropertyName("contract-limit")]
    public int? ContractLimit { get; set; }

    [JsonPropertyName("base-tick")]
    public int? BaseTick { get; set; }

    [JsonPropertyName("price-format")]
    public string PriceFormat { get; set; }

    [JsonPropertyName("sub-tick")]
    public int? SubTick { get; set; }
}

public class Roll
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("active-count")]
    public int ActiveCount { get; set; }

    [JsonPropertyName("cash-settled")]
    public bool CashSettled { get; set; }

    [JsonPropertyName("business-days-offset")]
    public int BusinessDaysOffset { get; set; }

    [JsonPropertyName("first-notice")]
    public bool FirstNotice { get; set; }
}

public class SpreadTickSize
{
    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }
}
