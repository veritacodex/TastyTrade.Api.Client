using System;
using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class AccountBalanceResponse
{
    [JsonProperty("data")]
    public AccountBalanceData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}

public class AccountBalanceData
{
    [JsonProperty("account-number")]
    public string AccountNumber { get; set; }

    [JsonProperty("available-trading-funds")]
    public string AvailableTradingFunds { get; set; }

    [JsonProperty("bond-margin-requirement")]
    public string BondMarginRequirement { get; set; }

    [JsonProperty("cash-available-to-withdraw")]
    public string CashAvailableToWithdraw { get; set; }

    [JsonProperty("cash-balance")]
    public string CashBalance { get; set; }

    [JsonProperty("cash-settle-balance")]
    public string CashSettleBalance { get; set; }

    [JsonProperty("closed-loop-available-balance")]
    public string ClosedLoopAvailableBalance { get; set; }

    [JsonProperty("cryptocurrency-margin-requirement")]
    public string CryptocurrencyMarginRequirement { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("day-equity-call-value")]
    public string DayEquityCallValue { get; set; }

    [JsonProperty("day-trade-excess")]
    public string DayTradeExcess { get; set; }

    [JsonProperty("day-trading-buying-power")]
    public string DayTradingBuyingPower { get; set; }

    [JsonProperty("day-trading-call-value")]
    public string DayTradingCallValue { get; set; }

    [JsonProperty("derivative-buying-power")]
    public string DerivativeBuyingPower { get; set; }

    [JsonProperty("equity-buying-power")]
    public string EquityBuyingPower { get; set; }

    [JsonProperty("equity-offering-margin-requirement")]
    public string EquityOfferingMarginRequirement { get; set; }

    [JsonProperty("futures-margin-requirement")]
    public string FuturesMarginRequirement { get; set; }

    [JsonProperty("long-bond-value")]
    public string LongBondValue { get; set; }

    [JsonProperty("long-cryptocurrency-value")]
    public string LongCryptocurrencyValue { get; set; }

    [JsonProperty("long-derivative-value")]
    public string LongDerivativeValue { get; set; }

    [JsonProperty("long-equity-value")]
    public string LongEquityValue { get; set; }

    [JsonProperty("long-futures-derivative-value")]
    public string LongFuturesDerivativeValue { get; set; }

    [JsonProperty("long-futures-value")]
    public string LongFuturesValue { get; set; }

    [JsonProperty("long-margineable-value")]
    public string LongMargineableValue { get; set; }

    [JsonProperty("maintenance-call-value")]
    public string MaintenanceCallValue { get; set; }

    [JsonProperty("maintenance-requirement")]
    public string MaintenanceRequirement { get; set; }

    [JsonProperty("margin-equity")]
    public string MarginEquity { get; set; }

    [JsonProperty("margin-settle-balance")]
    public string MarginSettleBalance { get; set; }

    [JsonProperty("net-liquidating-value")]
    public string NetLiquidatingValue { get; set; }

    [JsonProperty("pending-cash")]
    public string PendingCash { get; set; }

    [JsonProperty("pending-cash-effect")]
    public string PendingCashEffect { get; set; }

    [JsonProperty("reg-t-call-value")]
    public string RegTCallValue { get; set; }

    [JsonProperty("short-cryptocurrency-value")]
    public string ShortCryptocurrencyValue { get; set; }

    [JsonProperty("short-derivative-value")]
    public string ShortDerivativeValue { get; set; }

    [JsonProperty("short-equity-value")]
    public string ShortEquityValue { get; set; }

    [JsonProperty("short-futures-derivative-value")]
    public string ShortFuturesDerivativeValue { get; set; }

    [JsonProperty("short-futures-value")]
    public string ShortFuturesValue { get; set; }

    [JsonProperty("short-margineable-value")]
    public string ShortMargineableValue { get; set; }

    [JsonProperty("sma-equity-option-buying-power")]
    public string SmaEquityOptionBuyingPower { get; set; }

    [JsonProperty("special-memorandum-account-apex-adjustment")]
    public string SpecialMemorandumAccountApexAdjustment { get; set; }

    [JsonProperty("special-memorandum-account-value")]
    public string SpecialMemorandumAccountValue { get; set; }

    [JsonProperty("total-settle-balance")]
    public string TotalSettleBalance { get; set; }

    [JsonProperty("unsettled-cryptocurrency-fiat-amount")]
    public string UnsettledCryptocurrencyFiatAmount { get; set; }

    [JsonProperty("unsettled-cryptocurrency-fiat-effect")]
    public string UnsettledCryptocurrencyFiatEffect { get; set; }

    [JsonProperty("used-derivative-buying-power")]
    public string UsedDerivativeBuyingPower { get; set; }

    [JsonProperty("snapshot-date")]
    public string SnapshotDate { get; set; }

    [JsonProperty("reg-t-margin-requirement")]
    public string RegTMarginRequirement { get; set; }

    [JsonProperty("futures-overnight-margin-requirement")]
    public string FuturesOvernightMarginRequirement { get; set; }

    [JsonProperty("futures-intraday-margin-requirement")]
    public string FuturesIntradayMarginRequirement { get; set; }

    [JsonProperty("maintenance-excess")]
    public string MaintenanceExcess { get; set; }

    [JsonProperty("pending-margin-interest")]
    public string PendingMarginInterest { get; set; }

    [JsonProperty("effective-cryptocurrency-buying-power")]
    public string EffectiveCryptocurrencyBuyingPower { get; set; }

    [JsonProperty("updated-at")]
    public DateTime UpdatedAt { get; set; }
}