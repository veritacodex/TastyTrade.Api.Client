using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class SearchResponse
{
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("listed-market")]
    public string ListedMarket { get; set; }

    [JsonProperty("price-increments")]
    public string PriceIncrements { get; set; }

    [JsonProperty("trading-hours")]
    public string TradingHours { get; set; }

    [JsonProperty("options")]
    public string Options { get; set; }

    [JsonProperty("instrument-type")]
    public string InstrumentType { get; set; }
}
