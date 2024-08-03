using Newtonsoft.Json;

namespace TastyTrade.Client;

public partial class AccountsDataItem
{
    [JsonProperty("account")]
    public Account Account { get; set; }

    [JsonProperty("authority-level")]
    public string AuthorityLevel { get; set; }
}
