using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class FuturesContract
{
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("product-code")]
    public string ProductCode { get; set; }

    [JsonProperty("contract-size")]
    public string ContractSize { get; set; }

    [JsonProperty("tick-size")]
    public string TickSize { get; set; }

    [JsonProperty("notional-multiplier")]
    public string NotionalMultiplier { get; set; }

    [JsonProperty("main-fraction")]
    public string MainFraction { get; set; }

    [JsonProperty("sub-fraction")]
    public string SubFraction { get; set; }

    [JsonProperty("display-factor")]
    public string DisplayFactor { get; set; }

    [JsonProperty("last-trade-date")]
    public string LastTradeDate { get; set; }

    [JsonProperty("expiration-date")]
    public string ExpirationDate { get; set; }

    [JsonProperty("closing-only-date")]
    public string ClosingOnlyDate { get; set; }

    [JsonProperty("active")]
    public bool Active { get; set; }

    [JsonProperty("active-month")]
    public bool ActiveMonth { get; set; }

    [JsonProperty("next-active-month")]
    public bool NextActiveMonth { get; set; }

    [JsonProperty("is-closing-only")]
    public bool IsClosingOnly { get; set; }

    [JsonProperty("stops-trading-at")]
    public DateTime StopsTradingAt { get; set; }

    [JsonProperty("expires-at")]
    public DateTime ExpiresAt { get; set; }

    [JsonProperty("product-group")]
    public string ProductGroup { get; set; }

    [JsonProperty("exchange")]
    public string Exchange { get; set; }

    [JsonProperty("roll-target-symbol")]
    public string RollTargetSymbol { get; set; }

    [JsonProperty("streamer-exchange-code")]
    public string StreamerExchangeCode { get; set; }

    [JsonProperty("streamer-symbol")]
    public string StreamerSymbol { get; set; }

    [JsonProperty("back-month-first-calendar-symbol")]
    public bool BackMonthFirstCalendarSymbol { get; set; }

    [JsonProperty("is-tradeable")]
    public bool IsTradeable { get; set; }

    [JsonProperty("future-etf-equivalent")]
    public FutureEtfEquivalent FutureEtfEquivalent { get; set; }

    [JsonProperty("future-product")]
    public FutureProduct FutureProduct { get; set; }

    [JsonProperty("tick-sizes")]
    public List<TickSize> TickSizes { get; set; }

    [JsonProperty("option-tick-sizes")]
    public List<OptionTickSize> OptionTickSizes { get; set; }

    [JsonProperty("spread-tick-sizes")]
    public List<SpreadTickSize> SpreadTickSizes { get; set; }

    [JsonProperty("first-notice-date")]
    public string FirstNoticeDate { get; set; }
}

public class FutureEtfEquivalent
{
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("share-quantity")]
    public int ShareQuantity { get; set; }
}

public class FutureProduct
{
    [JsonProperty("root-symbol")]
    public string RootSymbol { get; set; }

    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("clearing-code")]
    public string ClearingCode { get; set; }

    [JsonProperty("clearing-exchange-code")]
    public string ClearingExchangeCode { get; set; }

    [JsonProperty("clearport-code")]
    public string ClearportCode { get; set; }

    [JsonProperty("legacy-code")]
    public string LegacyCode { get; set; }

    [JsonProperty("exchange")]
    public string Exchange { get; set; }

    [JsonProperty("legacy-exchange-code")]
    public string LegacyExchangeCode { get; set; }

    [JsonProperty("product-type")]
    public string ProductType { get; set; }

    [JsonProperty("listed-months")]
    public List<string> ListedMonths { get; set; }

    [JsonProperty("active-months")]
    public List<string> ActiveMonths { get; set; }

    [JsonProperty("notional-multiplier")]
    public string NotionalMultiplier { get; set; }

    [JsonProperty("tick-size")]
    public string TickSize { get; set; }

    [JsonProperty("display-factor")]
    public string DisplayFactor { get; set; }

    [JsonProperty("streamer-exchange-code")]
    public string StreamerExchangeCode { get; set; }

    [JsonProperty("small-notional")]
    public bool SmallNotional { get; set; }

    [JsonProperty("back-month-first-calendar-symbol")]
    public bool BackMonthFirstCalendarSymbol { get; set; }

    [JsonProperty("first-notice")]
    public bool FirstNotice { get; set; }

    [JsonProperty("cash-settled")]
    public bool CashSettled { get; set; }

    [JsonProperty("security-group")]
    public string SecurityGroup { get; set; }

    [JsonProperty("market-sector")]
    public string MarketSector { get; set; }

    [JsonProperty("roll")]
    public Roll Roll { get; set; }

    [JsonProperty("contract-limit")]
    public int? ContractLimit { get; set; }

    [JsonProperty("base-tick")]
    public int? BaseTick { get; set; }

    [JsonProperty("price-format")]
    public string PriceFormat { get; set; }

    [JsonProperty("sub-tick")]
    public int? SubTick { get; set; }
}

public class OptionTickSize
{
    [JsonProperty("value")]
    public string Value { get; set; }

    [JsonProperty("threshold")]
    public string Threshold { get; set; }
}

public class Roll
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("active-count")]
    public int ActiveCount { get; set; }

    [JsonProperty("cash-settled")]
    public bool CashSettled { get; set; }

    [JsonProperty("business-days-offset")]
    public int BusinessDaysOffset { get; set; }

    [JsonProperty("first-notice")]
    public bool FirstNotice { get; set; }
}

public class SpreadTickSize
{
    [JsonProperty("value")]
    public string Value { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }
}

public class TickSize
{
    [JsonProperty("value")]
    public string Value { get; set; }
}
