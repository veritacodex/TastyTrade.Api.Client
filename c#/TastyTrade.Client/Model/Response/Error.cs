using Newtonsoft.Json;

namespace TastyTrade.Client.Model.Response;

public class Error
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
