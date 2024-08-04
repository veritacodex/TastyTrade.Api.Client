using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public partial class Accounts
{
    [JsonProperty("data")]
    public AccountsData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}

public partial class AccountsData
{
    [JsonProperty("items")]
    public AccountsDataItem[] Items { get; set; }
}

public partial class AccountsDataItem
{
    [JsonProperty("account")]
    public Account Account { get; set; }

    [JsonProperty("authority-level")]
    public string AuthorityLevel { get; set; }
}

