using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public partial class CustomerSuitability
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("marital-status")]
    public string MaritalStatus { get; set; }

    [JsonProperty("number-of-dependents")]
    public long NumberOfDependents { get; set; }

    [JsonProperty("employment-status")]
    public string EmploymentStatus { get; set; }

    [JsonProperty("occupation")]
    public string Occupation { get; set; }

    [JsonProperty("employer-name")]
    public string EmployerName { get; set; }

    [JsonProperty("job-title")]
    public string JobTitle { get; set; }

    [JsonProperty("annual-net-income")]
    public long AnnualNetIncome { get; set; }

    [JsonProperty("net-worth")]
    public long NetWorth { get; set; }

    [JsonProperty("liquid-net-worth")]
    public long LiquidNetWorth { get; set; }

    [JsonProperty("stock-trading-experience")]
    public string StockTradingExperience { get; set; }

    [JsonProperty("covered-options-trading-experience")]
    public string CoveredOptionsTradingExperience { get; set; }

    [JsonProperty("uncovered-options-trading-experience")]
    public string UncoveredOptionsTradingExperience { get; set; }

    [JsonProperty("futures-trading-experience")]
    public string FuturesTradingExperience { get; set; }
}
