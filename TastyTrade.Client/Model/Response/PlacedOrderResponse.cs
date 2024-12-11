using System.Collections.Generic;
using System.Text.Json.Serialization;
using TastyTrade.Client.Model.Request;

namespace TastyTrade.Client.Model.Response
{
    public class PlacedOrderResponse
    {
        [JsonPropertyName("data")]
        public PlacedOrderResponseData Data { get; set; }

        [JsonPropertyName("context")]
        public string Context { get; set; }

        [JsonPropertyName("error")]
        public Error Error { get; set; }
    }
    public class PlacedOrderResponseData
    {
        [JsonPropertyName("buying-power-effect")]
        public BuyingPowerChangeEffect BuyingPowerEffect { get; set; }

        [JsonPropertyName("fee-calculation")]
        public FeeCalculation FeeCalculation { get; set; }

        [JsonPropertyName("order")]
        public PlacedOrderReceipt Order { get; set; }

        [JsonPropertyName("warnings")]
        public List<InnerErrorOrWarning> Warnings { get; set; }
    }
    public class PlacedOrderReceipt
    {
        [JsonPropertyName("id")]
        public long OrderId { get; set; }

        [JsonPropertyName("account-number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("cancellable")]
        public bool Cancellable { get; set; }

        [JsonPropertyName("editable")]
        public bool Editable { get; set; }

        [JsonPropertyName("edited")]
        public bool Edited { get; set; }

        [JsonPropertyName("global-request-id")]
        public string GlobalRequestId { get; set; }

        [JsonPropertyName("order-type")]
        public string OrderType { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("price-effect")]
        public string PriceEffect { get; set; }

        [JsonPropertyName("received-at")]
        public string ReceivedAt { get; set; }

        [JsonPropertyName("size")]
        public decimal Size { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("time-in-force")]
        public string TimeInForce { get; set; }

        [JsonPropertyName("underlying-instrument-type")]
        public string UnderlyingInstrumentType { get; set; }

        [JsonPropertyName("underlying-symbol")]
        public string UnderlyingSymbol { get; set; }

        [JsonPropertyName("updated-at")]
        public long UpdatedAt { get; set; }

        [JsonPropertyName("legs")]
        public List<PlacedOrderLegResponse> Legs { get; set; }
    }

    public class PlacedOrderLegResponse
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("instrument-type")]
        public InstrumentType InstrumentType { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("quantity")]
        public decimal Quantity { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("action")]
        public OrderLegAction Action { get; set; }

        [JsonPropertyName("remaining-quantity")]
        public decimal RemainingQuantity { get; set; }

        [JsonPropertyName("fills")]
        public List<PlacedOrderLegFill?> Fills { get; set; }
    }
    public class PlacedOrderLegFill
    {
        [JsonPropertyName("destination-venue")]
        public string DestinationVenue { get; set; }

        [JsonPropertyName("ext-exec-id")]
        public string ExtExecId { get; set; }

        [JsonPropertyName("ext-group-fill-id")]
        public string ExtGroupFillId { get; set; }

        [JsonPropertyName("fill-id")]
        public string FillId { get; set; }

        [JsonPropertyName("fill-price")]
        public decimal FillPrice { get; set; }

        [JsonPropertyName("filled-at")]
        public string FilledAt { get; set; }

        [JsonPropertyName("quantity")]
        public decimal Quantity { get; set; }
    }
    public class BuyingPowerChangeEffect
    {
        [JsonPropertyName("change-in-margin-requirement")]
        public string ChangeInMarginRequirement { get; set; }

        [JsonPropertyName("change-in-margin-requirement-effect")]
        public string ChangeInMarginRequirementEffect { get; set; }

        [JsonPropertyName("change-in-buying-power")]
        public string ChangeInBuyingPower { get; set; }

        [JsonPropertyName("current-buying-power-effect")]
        public string CurrentBuyingPowerEffect { get; set; }

        [JsonPropertyName("current-buying-power")]
        public string CurrentBuyingPower { get; set; }

        [JsonPropertyName("new-buying-power")]
        public string NewBuyingPower { get; set; }

        [JsonPropertyName("new-buying-power-effect")]
        public string NewBuyingPowerEffect { get; set; }

        [JsonPropertyName("isolated-order-margin-requirement")]
        public string IsolatedOrderMarginRequirement { get; set; }

        [JsonPropertyName("isolated-order-margin-requirement-effect")]
        public string IsolatedOrderMarginRequirementEffect { get; set; }

        [JsonPropertyName("is-spread")]
        public bool IsSpread { get; set; }

        [JsonPropertyName("impact")]
        public string Impact { get; set; }

        [JsonPropertyName("effect")]
        public string Effect { get; set; }
    }

    public class FeeCalculation
    {
        [JsonPropertyName("regulatory-fees")]
        public string RegulatoryFees { get; set; }

        [JsonPropertyName("regulatory-fees-effect")]
        public string RegulatoryFeesEffect { get; set; }

        [JsonPropertyName("regulatory-fees-breakdown")]
        public List<FeeBreakdown> RegulatoryFeesBreakdown { get; set; }

        [JsonPropertyName("clearing-fees")]
        public string ClearingFees { get; set; }

        [JsonPropertyName("clearing-fees-effect")]
        public string ClearingFeesEffect { get; set; }

        [JsonPropertyName("clearing-fees-breakdown")]
        public List<FeeBreakdown> ClearingFeesBreakdown { get; set; }

        [JsonPropertyName("commission")]
        public string Commission { get; set; }

        [JsonPropertyName("commission-effect")]
        public string CommissionEffect { get; set; }

        [JsonPropertyName("commission-breakdown")]
        public List<FeeBreakdown> CommissionBreakdown { get; set; }

        [JsonPropertyName("proprietary-index-option-fees")]
        public string ProprietaryIndexOptionFees { get; set; }

        [JsonPropertyName("proprietary-index-option-fees-effect")]
        public string ProprietaryIndexOptionFeesEffect { get; set; }

        [JsonPropertyName("proprietary-fees-breakdown")]
        public List<FeeBreakdown> ProprietaryFeesBreakdown { get; set; }

        [JsonPropertyName("total-fees")]
        public string TotalFees { get; set; }

        [JsonPropertyName("total-fees-effect")]
        public string TotalFeesEffect { get; set; }

        [JsonPropertyName("rebates")]
        public string Rebates { get; set; }

        [JsonPropertyName("rebates-effect")]
        public string RebatesEffect { get; set; }

        [JsonPropertyName("rebates-breakdown")]
        public List<FeeBreakdown> RebatesBreakdown { get; set; }

        [JsonPropertyName("per-quantity")]
        public bool PerQuantity { get; set; }
    }

    public class FeeBreakdown
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("effect")]
        public string Effect { get; set; }
    }
}