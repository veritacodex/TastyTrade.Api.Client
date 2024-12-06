using System;
using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Response;

public class AccountBalanceResponse
{
    [JsonPropertyName("data")]
    public AccountBalanceData Data { get; set; }

    [JsonPropertyName("context")]
    public string Context { get; set; }
}

public class AccountBalanceData
{
    [JsonPropertyName("account-number")]
    public string AccountNumber { get; set; }

    [JsonPropertyName("available-trading-funds")]
    public string AvailableTradingFunds { get; set; }

    [JsonPropertyName("bond-margin-requirement")]
    public string BondMarginRequirement { get; set; }

    [JsonPropertyName("cash-available-to-withdraw")]
    public string CashAvailableToWithdraw { get; set; }

    [JsonPropertyName("cash-balance")]
    public string CashBalance { get; set; }

    [JsonPropertyName("cash-settle-balance")]
    public string CashSettleBalance { get; set; }

    [JsonPropertyName("closed-loop-available-balance")]
    public string ClosedLoopAvailableBalance { get; set; }

    [JsonPropertyName("cryptocurrency-margin-requirement")]
    public string CryptocurrencyMarginRequirement { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("day-equity-call-value")]
    public string DayEquityCallValue { get; set; }

    [JsonPropertyName("day-trade-excess")]
    public string DayTradeExcess { get; set; }

    [JsonPropertyName("day-trading-buying-power")]
    public string DayTradingBuyingPower { get; set; }

    [JsonPropertyName("day-trading-call-value")]
    public string DayTradingCallValue { get; set; }

    [JsonPropertyName("derivative-buying-power")]
    public string DerivativeBuyingPower { get; set; }

    [JsonPropertyName("equity-buying-power")]
    public string EquityBuyingPower { get; set; }

    [JsonPropertyName("equity-offering-margin-requirement")]
    public string EquityOfferingMarginRequirement { get; set; }

    [JsonPropertyName("futures-margin-requirement")]
    public string FuturesMarginRequirement { get; set; }

    [JsonPropertyName("long-bond-value")]
    public string LongBondValue { get; set; }

    [JsonPropertyName("long-cryptocurrency-value")]
    public string LongCryptocurrencyValue { get; set; }

    [JsonPropertyName("long-derivative-value")]
    public string LongDerivativeValue { get; set; }

    [JsonPropertyName("long-equity-value")]
    public string LongEquityValue { get; set; }

    [JsonPropertyName("long-futures-derivative-value")]
    public string LongFuturesDerivativeValue { get; set; }

    [JsonPropertyName("long-futures-value")]
    public string LongFuturesValue { get; set; }

    [JsonPropertyName("long-margineable-value")]
    public string LongMargineableValue { get; set; }

    [JsonPropertyName("maintenance-call-value")]
    public string MaintenanceCallValue { get; set; }

    [JsonPropertyName("maintenance-requirement")]
    public string MaintenanceRequirement { get; set; }

    [JsonPropertyName("margin-equity")]
    public string MarginEquity { get; set; }

    [JsonPropertyName("margin-settle-balance")]
    public string MarginSettleBalance { get; set; }

    [JsonPropertyName("net-liquidating-value")]
    public string NetLiquidatingValue { get; set; }

    [JsonPropertyName("pending-cash")]
    public string PendingCash { get; set; }

    [JsonPropertyName("pending-cash-effect")]
    public string PendingCashEffect { get; set; }

    [JsonPropertyName("reg-t-call-value")]
    public string RegTCallValue { get; set; }

    [JsonPropertyName("short-cryptocurrency-value")]
    public string ShortCryptocurrencyValue { get; set; }

    [JsonPropertyName("short-derivative-value")]
    public string ShortDerivativeValue { get; set; }

    [JsonPropertyName("short-equity-value")]
    public string ShortEquityValue { get; set; }

    [JsonPropertyName("short-futures-derivative-value")]
    public string ShortFuturesDerivativeValue { get; set; }

    [JsonPropertyName("short-futures-value")]
    public string ShortFuturesValue { get; set; }

    [JsonPropertyName("short-margineable-value")]
    public string ShortMargineableValue { get; set; }

    [JsonPropertyName("sma-equity-option-buying-power")]
    public string SmaEquityOptionBuyingPower { get; set; }

    [JsonPropertyName("special-memorandum-account-apex-adjustment")]
    public string SpecialMemorandumAccountApexAdjustment { get; set; }

    [JsonPropertyName("special-memorandum-account-value")]
    public string SpecialMemorandumAccountValue { get; set; }

    [JsonPropertyName("total-settle-balance")]
    public string TotalSettleBalance { get; set; }

    [JsonPropertyName("unsettled-cryptocurrency-fiat-amount")]
    public string UnsettledCryptocurrencyFiatAmount { get; set; }

    [JsonPropertyName("unsettled-cryptocurrency-fiat-effect")]
    public string UnsettledCryptocurrencyFiatEffect { get; set; }

    [JsonPropertyName("used-derivative-buying-power")]
    public string UsedDerivativeBuyingPower { get; set; }

    [JsonPropertyName("snapshot-date")]
    public string SnapshotDate { get; set; }

    [JsonPropertyName("reg-t-margin-requirement")]
    public string RegTMarginRequirement { get; set; }

    [JsonPropertyName("futures-overnight-margin-requirement")]
    public string FuturesOvernightMarginRequirement { get; set; }

    [JsonPropertyName("futures-intraday-margin-requirement")]
    public string FuturesIntradayMarginRequirement { get; set; }

    [JsonPropertyName("maintenance-excess")]
    public string MaintenanceExcess { get; set; }

    [JsonPropertyName("pending-margin-interest")]
    public string PendingMarginInterest { get; set; }

    [JsonPropertyName("effective-cryptocurrency-buying-power")]
    public string EffectiveCryptocurrencyBuyingPower { get; set; }

    [JsonPropertyName("updated-at")]
    public DateTime UpdatedAt { get; set; }
}