using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class TickSize
{
    [JsonProperty("value")]
    public string Value { get; set; }

    [JsonProperty("threshold", NullValueHandling = NullValueHandling.Ignore)]
    public string Threshold { get; set; }
}
