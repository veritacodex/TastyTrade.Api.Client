using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TastyTrade.Client.Model.Request;

namespace TastyTrade.Client.Model.Response
{
    public class PlacedOrderResponse
    {

        [JsonProperty("data")]
        public PlacedOrderResponseData Data { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }
    }
    public class PlacedOrderResponseData
    {
        [JsonProperty("buying-power-effect")]
        public BuyingPowerChangeEffect BuyingPowerEffect { get; set; }

        [JsonProperty("fee-calculation")]
        public FeeCalculation FeeCalculation { get; set; }

        [JsonProperty("order")]
        public PlacedOrderReceipt Order { get; set; }

        [JsonProperty("warnings")]
        public List<InnerErrorOrWarning> Warnings { get; set; }

    }
    public class PlacedOrderReceipt
    {
        [JsonProperty("id")]
        public long OrderId { get; set; }

        [JsonProperty("account-number")]
        public string AccountNumber { get; set; }

        [JsonProperty("cancellable")]
        public bool Cancellable { get; set; }

        [JsonProperty("editable")]
        public bool Editable { get; set; }

        [JsonProperty("edited")]
        public bool Edited { get; set; }


        [JsonProperty("global-request-id")]
        public string GlobalRequestId { get; set; }

        [JsonProperty("order-type")]
        public string OrderType { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("price-effect")]
        public string PriceEffect { get; set; }

        [JsonProperty("received-at")]
        public string ReceivedAt { get; set; }

        [JsonProperty("size")]
        public decimal Size { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("time-in-force")]
        public string TimeInForce { get; set; }

        [JsonProperty("underlying-instrument-type")]
        public string UnderlyingInstrumentType { get; set; }

        [JsonProperty("underlying-symbol")]
        public string UnderlyingSymbol { get; set; }

        [JsonProperty("updated-at")]
        public long UpdatedAt { get; set; }

        [JsonProperty("legs")]
        public List<PlacedOrderLegResponse> Legs { get; set; }

    }

    public class PlacedOrderLegResponse  {

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("instrument-type")]
        public InstrumentType InstrumentType { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("action")]
        public OrderLegAction Action { get; set; }

        [JsonProperty("remaining-quantity")]
        public string RemainingQuantity { get; set; }

        [JsonProperty("fills")]
        public List<PlacedOrderLegFill?> Fills { get; set; }
    }
    public class PlacedOrderLegFill
    {
        
        [JsonProperty("destination-venue")]
        public string DestinationVenue { get; set; }

        [JsonProperty("ext-exec-id")]
        public string ExtExecId { get; set; }
 
        [JsonProperty("ext-group-fill-id")]
        public string ExtGroupFillId { get; set; }

        [JsonProperty("fill-id")]
        public string FillId { get; set; }

        [JsonProperty("fill-price")]
        public decimal FillPrice { get; set; }
        
        [JsonProperty("filled-at")]
        public string FilledAt { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

    }
    public class BuyingPowerChangeEffect
    {
        [JsonProperty("change-in-margin-requirement")]
        public string ChangeInMarginRequirement { get; set; }

        [JsonProperty("change-in-margin-requirement-effect")]
        public string ChangeInMarginRequirementEffect { get; set; }

        [JsonProperty("change-in-buying-power")]
        public string ChangeInBuyingPower { get; set; }

        [JsonProperty("current-buying-power-effect")]
        public string CurrentBuyingPowerEffect
        { get; set; }

        [JsonProperty("current-buying-power")]
        public string CurrentBuyingPower { get; set; }


        [JsonProperty("new-buying-power")]
        public string NewBuyingPower
        { get; set; }
        [JsonProperty("new-buying-power-effect")]
        public string NewBuyingPowerEffect
        { get; set; }
        [JsonProperty("isolated-order-margin-requirement")]
        public string IsolatedOrderMarginRequirement
        { get; set; }
        [JsonProperty("isolated-order-margin-requirement-effect")]
        public string IsolatedOrderMarginRequirementEffect
        { get; set; }
        [JsonProperty("is-spread")]
        public bool IsSpread
        { get; set; }
        [JsonProperty("Impact")]
        public string impact
        { get; set; }
        [JsonProperty("effect")]
        public string Effect
        { get; set; }
    }

    public class FeeCalculation
    {

        [JsonProperty("regulatory-fees")]
        public string RegulatoryFees { get; set; }

        [JsonProperty("regulatory-fees-effect")]
        public string RegulatoryFeesEffect { get; set; }

        [JsonProperty("regulatory-fees-breakdown")]
        public List<FeeBreakdown> RegulatoryFeesBreakdown { get; set; }

        [JsonProperty("clearing-fees")]
        public string ClearingFees { get; set; }

        [JsonProperty("clearing-fees-effect")]
        public string ClearingFeesEffect { get; set; }

        [JsonProperty("clearing-fees-breakdown")]
        public List<FeeBreakdown> ClearingFeesBreakdown { get; set; }

        [JsonProperty("commission")]
        public string Commission { get; set; }

        [JsonProperty("commission-effect")]
        public string CommissionEffect { get; set; }

        [JsonProperty("commission-breakdown")]
        public List<FeeBreakdown> CommissionBreakdown { get; set; }


        [JsonProperty("proprietary-index-option-fees")]
        public string ProprietaryIndexOptionFees { get; set; }

        [JsonProperty("proprietary-index-option-fees-effect")]
        public string ProprietaryIndexOptionFeesEffect { get; set; }

        [JsonProperty("proprietary-fees-breakdown")]
        public List<FeeBreakdown> ProprietaryFeesBreakdown { get; set; }

        [JsonProperty("total-fees")]
        public string TotalFees { get; set; }

        [JsonProperty("total-fees-effect")]
        public string TotalFeesEffect { get; set; }

        [JsonProperty("rebates")]
        public string Rebates { get; set; }

        [JsonProperty("rebates-effect")]
        public string RebatesEffect { get; set; }

        [JsonProperty("rebates-breakdown")]
        public List<FeeBreakdown> RebatesBreakdown { get; set; }

        [JsonProperty("per-quantity")]
        public bool PerQuantity { get; set; }

    }

    public class FeeBreakdown
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("effect")]
        public string Effect { get; set; }
    }

}
