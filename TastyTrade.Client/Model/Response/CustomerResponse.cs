using System;
using System.Text.Json.Serialization;

namespace TastyTrade.Client.Model.Response;

public class CustomerResponse
{
    [JsonPropertyName("data")]
    public CustomerResponseData Data { get; set; }

    [JsonPropertyName("context")]
    public string Context { get; set; }
}

public class CustomerResponseData
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("first-name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last-name")]
    public string LastName { get; set; }

    [JsonPropertyName("address")]
    public CustomerResponseAddress Address { get; set; }

    [JsonPropertyName("mailing-address")]
    public CustomerResponseAddress MailingAddress { get; set; }

    [JsonPropertyName("usa-citizenship-type")]
    public string UsaCitizenshipType { get; set; }

    [JsonPropertyName("is-foreign")]
    public bool IsForeign { get; set; }

    [JsonPropertyName("mobile-phone-number")]
    public string MobilePhoneNumber { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("tax-number-type")]
    public string TaxNumberType { get; set; }

    [JsonPropertyName("birth-date")]
    public DateTimeOffset BirthDate { get; set; }

    [JsonPropertyName("subject-to-tax-withholding")]
    public bool SubjectToTaxWithholding { get; set; }

    [JsonPropertyName("agreed-to-margining")]
    public bool AgreedToMargining { get; set; }

    [JsonPropertyName("has-industry-affiliation")]
    public bool HasIndustryAffiliation { get; set; }

    [JsonPropertyName("has-political-affiliation")]
    public bool HasPoliticalAffiliation { get; set; }

    [JsonPropertyName("has-listed-affiliation")]
    public bool HasListedAffiliation { get; set; }

    [JsonPropertyName("is-professional")]
    public bool IsProfessional { get; set; }

    [JsonPropertyName("has-delayed-quotes")]
    public bool HasDelayedQuotes { get; set; }

    [JsonPropertyName("has-pending-or-approved-application")]
    public bool HasPendingOrApprovedApplication { get; set; }

    [JsonPropertyName("permitted-account-types")]
    public CustomerResponsePermittedAccountType[] PermittedAccountTypes { get; set; }

    [JsonPropertyName("created-at")]
    public DateTimeOffset CreatedAt { get; set; }
}

public class CustomerResponseAddress
{
    [JsonPropertyName("street-one")]
    public string StreetOne { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("state-region")]
    public string StateRegion { get; set; }

    [JsonPropertyName("postal-code")]
    public string PostalCode { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("is-foreign")]
    public bool IsForeign { get; set; }

    [JsonPropertyName("is-domestic")]
    public bool IsDomestic { get; set; }
}

public class CustomerResponsePermittedAccountType
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("is_tax_advantaged")]
    public bool IsTaxAdvantaged { get; set; }

    [JsonPropertyName("has_multiple_owners")]
    public bool HasMultipleOwners { get; set; }

    [JsonPropertyName("is_publicly_available")]
    public bool IsPubliclyAvailable { get; set; }

    [JsonPropertyName("margin_types")]
    public CustomerResponseMarginType[] MarginTypes { get; set; }
}

public class CustomerResponseMarginType
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("is_margin")]
    public bool IsMargin { get; set; }
}