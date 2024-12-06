using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Response;

public class ApiQuoteTokenResponse
{
    [JsonPropertyName("data")]
    public ApiQuoteTokenData Data { get; set; }

    [JsonPropertyName("context")]
    public string Context { get; set; }
}

public class ApiQuoteTokenData
{
    [JsonPropertyName("token")]
    public string Token { get; set; }

    [JsonPropertyName("dxlink-url")]
    public string DxlinkUrl { get; set; }

    [JsonPropertyName("level")]
    public string Level { get; set; }
}
