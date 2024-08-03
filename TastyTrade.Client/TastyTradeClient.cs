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

    public async Task AuthenticateAsync(AuthorizationCredentials credentials)
    {
        using var client = new HttpClient();
        using var content = new StringContent(JsonConvert.SerializeObject(credentials));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await client.PostAsync($"{_baseUrl}/sessions", content);
        var responseJson = await response.Content.ReadAsStringAsync();
        _authenticationResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(responseJson);
    }

    public async Task<Customer> GetCustomer()
    {
        var customerJson = await Get($"{_baseUrl}/customers/me");
        return JsonConvert.DeserializeObject<Customer>(customerJson);
    }

    private async Task<string> Get(string url)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_authenticationResponse.Data.SessionToken);
        var response = await client.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }

    // private static async Task<string> Post(string url, string requestContent)
    // {
    //     using var client = new HttpClient();
    //     using var content = new StringContent(requestContent);
    //     content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    //     var response = await client.PostAsync(url, content);
    //     return await response.Content.ReadAsStringAsync();
    // }
}
