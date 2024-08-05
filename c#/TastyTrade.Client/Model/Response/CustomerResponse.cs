using System;
using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class CustomerResponse
{
    [JsonProperty("data")]
    public CustomerData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}

public class CustomerData
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("first-name")]
    public string FirstName { get; set; }

    [JsonProperty("last-name")]
    public string LastName { get; set; }

    [JsonProperty("address")]
    public Address Address { get; set; }

    [JsonProperty("mailing-address")]
    public Address MailingAddress { get; set; }

    [JsonProperty("customer-suitability")]
    public CustomerSuitability CustomerSuitability { get; set; }

    [JsonProperty("usa-citizenship-type")]
    public string UsaCitizenshipType { get; set; }

    [JsonProperty("is-foreign")]
    public bool IsForeign { get; set; }

    [JsonProperty("mobile-phone-number")]
    public string MobilePhoneNumber { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("tax-number-type")]
    public string TaxNumberType { get; set; }

    [JsonProperty("tax-number")]
    public string TaxNumber { get; set; }

    [JsonProperty("birth-date")]
    public DateTimeOffset BirthDate { get; set; }

    [JsonProperty("external-id")]
    public string ExternalId { get; set; }

    [JsonProperty("citizenship-country")]
    public string CitizenshipCountry { get; set; }

    [JsonProperty("subject-to-tax-withholding")]
    public bool SubjectToTaxWithholding { get; set; }

    [JsonProperty("agreed-to-margining")]
    public bool AgreedToMargining { get; set; }

    [JsonProperty("agreed-to-terms")]
    public bool AgreedToTerms { get; set; }

    [JsonProperty("has-industry-affiliation")]
    public bool HasIndustryAffiliation { get; set; }

    [JsonProperty("has-political-affiliation")]
    public bool HasPoliticalAffiliation { get; set; }

    [JsonProperty("has-listed-affiliation")]
    public bool HasListedAffiliation { get; set; }

    [JsonProperty("is-professional")]
    public bool IsProfessional { get; set; }

    [JsonProperty("has-delayed-quotes")]
    public bool HasDelayedQuotes { get; set; }

    [JsonProperty("has-pending-or-approved-application")]
    public bool HasPendingOrApprovedApplication { get; set; }

    [JsonProperty("identifiable-type")]
    public string IdentifiableType { get; set; }

    [JsonProperty("person")]
    public Person Person { get; set; }
}

public class CustomerSuitability
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

