using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Request;

public class AuthorizationCredentials
{
    [JsonPropertyName("account-number")]
    public string AccountNumber { get; set; }

    [JsonPropertyName("login")]
    public string Login { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("remember-me")]
    public bool RememberMe { get; set; }

    [JsonPropertyName("user-agent")]
    public string UserAgent { get; set; }

    [JsonPropertyName("api-base-url")]
    public string ApiBaseUrl { get; set; }

    [JsonPropertyName("streaming-api-base-url")]
    public string StreamingApiBaseUrl { get; set; }
}
