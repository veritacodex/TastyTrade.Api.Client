using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Response;

public class SearchResponse
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("listed-market")]
    public string ListedMarket { get; set; }

    [JsonPropertyName("price-increments")]
    public string PriceIncrements { get; set; }

    [JsonPropertyName("trading-hours")]
    public string TradingHours { get; set; }

    [JsonPropertyName("options")]
    public string Options { get; set; }

    [JsonPropertyName("instrument-type")]
    public string InstrumentType { get; set; }
}
