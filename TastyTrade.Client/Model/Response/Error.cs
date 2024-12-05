using Newtonsoft.Json;
using System.Collections.Generic;

namespace TastyTrade.Client.Model.Response;

public class Error
{
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("errors")]
    public List<InnerErrorOrWarning> Errors { get; set; }

}

public class InnerErrorOrWarning
{
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

}
