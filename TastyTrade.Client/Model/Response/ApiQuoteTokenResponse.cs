using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class ApiQuoteTokenResponse
{
    [JsonProperty("data")]
    public ApiQuoteTokenData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}

public class ApiQuoteTokenData
{
    [JsonProperty("token")]
    public string Token { get; set; }

    [JsonProperty("dxlink-url")]
    public string DxlinkUrl { get; set; }

    [JsonProperty("level")]
    public string Level { get; set; }
}
