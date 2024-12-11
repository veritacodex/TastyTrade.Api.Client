using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Request
{
    public enum TimeInForce
    {
        Day = 0,
        GTD = 1,
        GTC = 2
    }

    public enum OrderType
    {
        [JsonStringEnumMemberName("Limit")]
        Limit = 0,

        [JsonStringEnumMemberName("Market")]
        Market = 1,

        [JsonStringEnumMemberName("Stop")]
        Stop = 2,

        [JsonStringEnumMemberName("Stop Limit")]
        StopLimit = 3,

        [JsonStringEnumMemberName("Notional Market")]
        NotionalMarket = 4
    }

    public enum PriceEffect
    {
        Debit = 0,
        Credit = 1
    }


    public enum InstrumentType
    {
        [JsonStringEnumMemberName("Equity")]
        Equity = 0,

        [JsonStringEnumMemberName("Equity Option")]
        EquityOption = 1,

        [JsonStringEnumMemberName("Future")]
        Future = 2,

        [JsonStringEnumMemberName("Future Option")]
        FutureOption = 3,

        [JsonStringEnumMemberName("Cryptocurrency")]
        Cryptocurrency = 4
    }

    public enum OrderLegAction
    {
        [JsonStringEnumMemberName("Buy to Open")]
        BuyToOpen = 0,

        [JsonStringEnumMemberName("Sell to Open")]
        SellToOpen = 1,

        [JsonStringEnumMemberName("Buy to Close")]
        BuyToClose = 2,

        [JsonStringEnumMemberName("Sell to Close")]
        SellToClose = 3,
    }

    public class PlaceOrderRequest
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("time-in-force")]
        public TimeInForce TimeInForce { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("order-type")]
        public OrderType OrderType { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("price-effect")]
        public PriceEffect PriceEffect { get; set; }

        [JsonPropertyName("legs")]
        public List<OrderSubmissionLeg> Legs { get; set; }
    }

    public class OrderSubmissionLeg
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
    }
}
