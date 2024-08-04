using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class AuthenticationResponse
{
    [JsonProperty("data")]
    public AuthenticationResponseData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }

    [JsonProperty("error")]
    public Error Error { get; set; }
}

public class AuthenticationResponseData
{
    [JsonProperty("user")]
    public AuthenticationResponseUser User { get; set; }

    [JsonProperty("session-token")]
    public string SessionToken { get; set; }

    [JsonProperty("remember-token")]
    public string RememberToken { get; set; }
}

public class AuthenticationResponseUser
{
    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("external-id")]
    public string ExternalId { get; set; }
}
