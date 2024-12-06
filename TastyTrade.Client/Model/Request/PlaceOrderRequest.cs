using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TastyTrade.Client.Model.Request
{
    public enum TimeInForce { 
        Day = 0,
        GTD = 1,
        GTC = 2
    }

    public enum OrderType {
        [EnumMember(Value = "Limit")]
        Limit = 0,

        [EnumMember(Value = "Market")]
        Market = 1,

        [EnumMember(Value = "Stop")]
        Stop = 2,

        [EnumMember(Value = "Stop Limit")]
        StopLimit = 3,

        [EnumMember(Value = "Notional Market")]
        NotionalMarket = 4
    }
    
    public enum PriceEffect { 
        Debit = 0,
        Credit = 1
    }

    public enum InstrumentType {
        [EnumMember(Value = "Equity")]
        Equity = 0,
        [EnumMember(Value = "Equity Option")]
        EquityOption = 1,
        [EnumMember(Value = "Future")]
        Future = 2,
        [EnumMember(Value = "Future Option")]
        FutureOption = 3,
        [EnumMember(Value = "Cryptocurrency")]
        Cryptocurrency = 4
    }

    public enum OrderLegAction {
        
        [EnumMember(Value = "Buy to Open")]
        BuyToOpen = 0,

        [EnumMember(Value = "Sell to Open")]
        SellToOpen = 1,

        [EnumMember(Value = "Buy to Close")]
        BuyToClose = 2,

        [EnumMember(Value = "Sell to Close")]
        SellToClose = 3,
    }

    public class PlaceOrderRequest
    {

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("time-in-force")]
        public TimeInForce TimeInForce { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("order-type")]
        public OrderType OrderType { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("price-effect")]
        public PriceEffect PriceEffect { get; set; }

        [JsonProperty("legs")]
        public List<OrderSubmissionLeg> Legs { get; set; }

    }

    public class OrderSubmissionLeg
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("instrument-type")]
        public InstrumentType InstrumentType { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("action")]
        public OrderLegAction Action { get; set; }

    }
}
