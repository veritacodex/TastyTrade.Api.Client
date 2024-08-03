using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public partial class AuthenticationResponseData
{
    [JsonProperty("user")]
    public AuthenticationResponseUser User { get; set; }

    [JsonProperty("session-token")]
    public string SessionToken { get; set; }

    [JsonProperty("remember-token")]
    public string RememberToken { get; set; }
}
