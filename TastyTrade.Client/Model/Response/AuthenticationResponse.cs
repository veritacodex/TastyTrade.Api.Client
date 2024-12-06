using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Response;

public class AuthenticationResponse
{
    [JsonPropertyName("data")]
    public AuthenticationResponseData Data { get; set; }

    [JsonPropertyName("context")]
    public string Context { get; set; }

    [JsonPropertyName("error")]
    public Error Error { get; set; }
}

public class AuthenticationResponseData
{
    [JsonPropertyName("user")]
    public AuthenticationResponseUser User { get; set; }

    [JsonPropertyName("session-token")]
    public string SessionToken { get; set; }

    [JsonPropertyName("remember-token")]
    public string RememberToken { get; set; }
}

public class AuthenticationResponseUser
{
    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("external-id")]
    public string ExternalId { get; set; }
}
