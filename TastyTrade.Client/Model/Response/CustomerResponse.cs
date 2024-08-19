using System;
using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class CustomerResponse
{
    [JsonProperty("data")]
    public CustomerResponseData Data { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }
}

public class CustomerResponseData
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("first-name")]
    public string FirstName { get; set; }

    [JsonProperty("last-name")]
    public string LastName { get; set; }

    [JsonProperty("address")]
    public CustomerResponseAddress Address { get; set; }

    [JsonProperty("mailing-address")]
    public CustomerResponseAddress MailingAddress { get; set; }

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

    [JsonProperty("birth-date")]
    public DateTimeOffset BirthDate { get; set; }

    [JsonProperty("subject-to-tax-withholding")]
    public bool SubjectToTaxWithholding { get; set; }

    [JsonProperty("agreed-to-margining")]
    public bool AgreedToMargining { get; set; }

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

    [JsonProperty("permitted-account-types")]
    public CustomerResponsePermittedAccountType[] PermittedAccountTypes { get; set; }

    [JsonProperty("created-at")]
    public DateTimeOffset CreatedAt { get; set; }
}

public class CustomerResponseAddress
{
    [JsonProperty("street-one")]
    public string StreetOne { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("state-region")]
    public string StateRegion { get; set; }

    [JsonProperty("postal-code")]
    public string PostalCode { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("is-foreign")]
    public bool IsForeign { get; set; }

    [JsonProperty("is-domestic")]
    public bool IsDomestic { get; set; }
}

public class CustomerResponsePermittedAccountType
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("is_tax_advantaged")]
    public bool IsTaxAdvantaged { get; set; }

    [JsonProperty("has_multiple_owners")]
    public bool HasMultipleOwners { get; set; }

    [JsonProperty("is_publicly_available")]
    public bool IsPubliclyAvailable { get; set; }

    [JsonProperty("margin_types")]
    public CustomerResponseMarginType[] MarginTypes { get; set; }
}

public class CustomerResponseMarginType
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("is_margin")]
    public bool IsMargin { get; set; }
}