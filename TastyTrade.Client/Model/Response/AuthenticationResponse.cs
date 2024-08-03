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
