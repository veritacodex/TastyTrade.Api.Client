using System;
using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class Person
{
    [JsonProperty("external-id")]
    public string ExternalId { get; set; }

    [JsonProperty("first-name")]
    public string FirstName { get; set; }

    [JsonProperty("last-name")]
    public string LastName { get; set; }

    [JsonProperty("birth-date")]
    public DateTimeOffset BirthDate { get; set; }

    [JsonProperty("citizenship-country")]
    public string CitizenshipCountry { get; set; }

    [JsonProperty("usa-citizenship-type")]
    public string UsaCitizenshipType { get; set; }

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
}