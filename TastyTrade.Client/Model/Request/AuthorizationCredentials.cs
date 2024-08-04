using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Request;

public class AuthorizationCredentials
{
    [JsonProperty("login")]
    public string Login { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; }

    [JsonProperty("remember-me")]
    public bool RememberMe { get; set; }

    [JsonProperty("user-agent")]
    public string UserAgent { get; set; }
}
