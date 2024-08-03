using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TastyTrade.Client.Model.Request;
using TastyTrade.Client.Model.Response;

namespace TastyTrade.Client;

public class TastyTradeClient
{
    private const string _baseUrl = "https://api.cert.tastyworks.com";
    private AuthenticationResponse _authenticationResponse;

    public async Task<AuthenticationResponse> AuthenticateAsync(AuthorizationCredentials credentials)
    {
        var response = await Post($"{_baseUrl}/sessions", JsonConvert.SerializeObject(credentials));
        _authenticationResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(response);
        return _authenticationResponse;
    }

    private static async Task<string> Post(string url, string requestContent)
    {
        using var client = new HttpClient();
        using var content = new StringContent(requestContent);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await client.PostAsync(url, content);
        return await response.Content.ReadAsStringAsync();
    }
}
