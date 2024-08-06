using System;
using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class AccountResponse
{
    [JsonProperty("data")]
    public AccountData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}

public class AccountData
{
    [JsonProperty("account-number")]
    public string AccountNumber { get; set; }

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

    [JsonProperty("investment-objective")]
    public string InvestmentObjective { get; set; }

    [JsonProperty("suitable-options-level")]
    public string SuitableOptionsLevel { get; set; }

    [JsonProperty("created-at")]
    public DateTimeOffset CreatedAt { get; set; }
}