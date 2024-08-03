using Newtonsoft.Json;

namespace TastyTrade.Client;

public partial class AccountsData
{
    [JsonProperty("items")]
    public AccountsDataItem[] Items { get; set; }
}
