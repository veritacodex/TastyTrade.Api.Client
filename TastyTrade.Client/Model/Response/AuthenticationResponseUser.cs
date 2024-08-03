using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public partial class AuthenticationResponseUser
{
    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("external-id")]
    public string ExternalId { get; set; }
}