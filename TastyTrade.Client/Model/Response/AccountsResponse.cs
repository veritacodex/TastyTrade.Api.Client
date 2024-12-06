using System;
using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Response;

public class AccountsResponse
{
    [JsonPropertyName("data")]
    public AccountsData Data { get; set; }

    [JsonPropertyName("context")]
    public string Context { get; set; }
}

public class AccountsData
{
    [JsonPropertyName("items")]
    public AccountsDataItem[] Items { get; set; }
}

public class AccountsDataItem
{
    [JsonPropertyName("account")]
    public AccountsDataItemAccount Account { get; set; }

    [JsonPropertyName("authority-level")]
    public string AuthorityLevel { get; set; }
}

public class AccountsDataItemAccount
{
    [JsonPropertyName("account-number")]
    public string AccountNumber { get; set; }

    [JsonPropertyName("external-id")]
    public string ExternalId { get; set; }

    [JsonPropertyName("opened-at")]
    public DateTimeOffset OpenedAt { get; set; }

    [JsonPropertyName("nickname")]
    public string Nickname { get; set; }

    [JsonPropertyName("account-type-name")]
    public string AccountTypeName { get; set; }

    [JsonPropertyName("day-trader-status")]
    public bool DayTraderStatus { get; set; }

    [JsonPropertyName("is-closed")]
    public bool IsClosed { get; set; }

    [JsonPropertyName("is-firm-error")]
    public bool IsFirmError { get; set; }

    [JsonPropertyName("is-firm-proprietary")]
    public bool IsFirmProprietary { get; set; }

    [JsonPropertyName("is-futures-approved")]
    public bool IsFuturesApproved { get; set; }

    [JsonPropertyName("is-test-drive")]
    public bool IsTestDrive { get; set; }

    [JsonPropertyName("margin-or-cash")]
    public string MarginOrCash { get; set; }

    [JsonPropertyName("is-foreign")]
    public bool IsForeign { get; set; }

    [JsonPropertyName("funding-date")]
    public DateTimeOffset FundingDate { get; set; }

    [JsonPropertyName("investment-objective")]
    public string InvestmentObjective { get; set; }

    [JsonPropertyName("futures-account-purpose")]
    public string FuturesAccountPurpose { get; set; }

    [JsonPropertyName("suitable-options-level")]
    public string SuitableOptionsLevel { get; set; }

    [JsonPropertyName("created-at")]
    public DateTimeOffset CreatedAt { get; set; }
}