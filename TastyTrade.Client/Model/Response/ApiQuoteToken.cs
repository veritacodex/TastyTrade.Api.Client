using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public partial class ApiQuoteToken
{
    [JsonProperty("data")]
    public ApiQuoteTokenData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}

public partial class ApiQuoteTokenData
{
    [JsonProperty("token")]
    public string Token { get; set; }

    [JsonProperty("dxlink-url")]
    public string DxlinkUrl { get; set; }

    [JsonProperty("level")]
    public string Level { get; set; }
}
