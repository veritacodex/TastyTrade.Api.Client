using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class Address
{
    [JsonProperty("street-one")]
    public string StreetOne { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("state-region")]
    public string StateRegion { get; set; }

    [JsonProperty("postal-code")]
    public string PostalCode { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("is-foreign")]
    public bool IsForeign { get; set; }

    [JsonProperty("is-domestic")]
    public bool IsDomestic { get; set; }
}
