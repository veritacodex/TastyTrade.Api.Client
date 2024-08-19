using System;
using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class AccountsResponse
{
    [JsonProperty("data")]
    public AccountsData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}

public class AccountsData
{
    [JsonProperty("items")]
    public AccountsDataItem[] Items { get; set; }
}

public class AccountsDataItem
{
    [JsonProperty("account")]
    public AccountsDataItemAccount Account { get; set; }

    [JsonProperty("authority-level")]
    public string AuthorityLevel { get; set; }
}

public class AccountsDataItemAccount
{
    [JsonProperty("account-number")]
    public string AccountNumber { get; set; }

    [JsonProperty("external-id")]
    public string ExternalId { get; set; }

    [JsonProperty("opened-at")]
    public DateTimeOffset OpenedAt { get; set; }

    [JsonProperty("nickname")]
    public string Nickname { get; set; }

    [JsonProperty("account-type-name")]
    public string AccountTypeName { get; set; }

    [JsonProperty("day-trader-status")]
    public bool DayTraderStatus { get; set; }

    [JsonProperty("is-closed")]
    public bool IsClosed { get; set; }

    [JsonProperty("is-firm-error")]
    public bool IsFirmError { get; set; }

    [JsonProperty("is-firm-proprietary")]
    public bool IsFirmProprietary { get; set; }

    [JsonProperty("is-futures-approved")]
    public bool IsFuturesApproved { get; set; }

    [JsonProperty("is-test-drive")]
    public bool IsTestDrive { get; set; }

    [JsonProperty("margin-or-cash")]
    public string MarginOrCash { get; set; }

    [JsonProperty("is-foreign")]
    public bool IsForeign { get; set; }

    [JsonProperty("funding-date")]
    public DateTimeOffset FundingDate { get; set; }

    [JsonProperty("investment-objective")]
    public string InvestmentObjective { get; set; }

    [JsonProperty("futures-account-purpose")]
    public string FuturesAccountPurpose { get; set; }

    [JsonProperty("suitable-options-level")]
    public string SuitableOptionsLevel { get; set; }

    [JsonProperty("created-at")]
    public DateTimeOffset CreatedAt { get; set; }
}