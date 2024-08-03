using Newtonsoft.Json;

namespace TastyTrade.Client;

public partial class Accounts
{
    [JsonProperty("data")]
    public AccountsData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}
