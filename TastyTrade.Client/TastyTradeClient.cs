using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TastyTrade.Client.Model;
using TastyTrade.Client.Model.Request;
using TastyTrade.Client.Model.Response;

namespace TastyTrade.Client;

public class TastyTradeClient
{
    private const string _baseUrl = "https://api.cert.tastyworks.com";
    private AuthenticationResponse _authenticationResponse;
    private string _userAgent;

    public async Task AuthenticateAsync(AuthorizationCredentials credentials)
    {
        using var client = new HttpClient();
        _userAgent = credentials.UserAgent;
        client.DefaultRequestHeaders.UserAgent.ParseAdd(credentials.UserAgent);
        using var content = new StringContent(JsonConvert.SerializeObject(credentials));
        content.Headers.ContentType = new MediaTypeHeaderValue(Constants.ContentType);
        var response = await client.PostAsync($"{_baseUrl}/sessions", content);
        var responseJson = await response.Content.ReadAsStringAsync();
        _authenticationResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(responseJson);
    }

    public async Task<Customer> GetCustomer()
    {
        var response = await Get($"{_baseUrl}/customers/me");
        return JsonConvert.DeserializeObject<Customer>(response);
    }

    public async Task<ApiQuoteToken> GetApiQuoteTokens()
    {
        var response = await Get($"{_baseUrl}/api-quote-tokens");
        return JsonConvert.DeserializeObject<ApiQuoteToken>(response);
    }

    public async Task<Accounts> GetAccounts()
    {
        var response = await Get($"{_baseUrl}/customers/me/accounts");
        return JsonConvert.DeserializeObject<Accounts>(response);
    }

    public async Task<Account> GetAccount(string accountNumber)
    {
        var response = await Get($"{_baseUrl}/customers/me/accounts/{accountNumber}");
        return JsonConvert.DeserializeObject<Account>(response);
    }

    public async Task<TradingStatus> GetAccountStatus(string accountNumber)
    {
        var response = await Get($"{_baseUrl}/accounts/{accountNumber}/trading-status");
        return JsonConvert.DeserializeObject<TradingStatus>(response);
    }

    private async Task<string> Get(string url)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.UserAgent.ParseAdd(_userAgent);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.Accept));
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
