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
    public async Task<CustomerResponse> GetCustomer()
    {
        var response = await Get($"{_baseUrl}/customers/me");
        return JsonConvert.DeserializeObject<CustomerResponse>(response);
    }
    public async Task<ApiQuoteTokenResponse> GetApiQuoteTokens()
    {
        var response = await Get($"{_baseUrl}/api-quote-tokens");
        return JsonConvert.DeserializeObject<ApiQuoteTokenResponse>(response);
    }
    public async Task<AccountsResponse> GetAccounts()
    {
        var response = await Get($"{_baseUrl}/customers/me/accounts");
        return JsonConvert.DeserializeObject<AccountsResponse>(response);
    }
    public async Task<AccountResponse> GetAccount(string accountNumber)
    {
        var response = await Get($"{_baseUrl}/customers/me/accounts/{accountNumber}");
        return JsonConvert.DeserializeObject<AccountResponse>(response);
    }
    public async Task<TradingStatusResponse> GetAccountStatus(string accountNumber)
    {
        var response = await Get($"{_baseUrl}/accounts/{accountNumber}/trading-status");
        return JsonConvert.DeserializeObject<TradingStatusResponse>(response);
    }
    public async Task<AccountBalanceResponse> GetAccountBalance(string accountNumber)
    {
        var response = await Get($"{_baseUrl}/accounts/{accountNumber}/balances");
        return JsonConvert.DeserializeObject<AccountBalanceResponse>(response);
    }
    public async Task<AccountBalanceResponse> GetAccountBalance(string accountNumber, string currency)
    {
        var response = await Get($"{_baseUrl}/accounts/{accountNumber}/balances/{currency}");
        return JsonConvert.DeserializeObject<AccountBalanceResponse>(response);
    }
    public async Task<AccountBalanceResponse> GetAccountBalanceSnapshot(string accountNumber)
    {
        var response = await Get($"{_baseUrl}/accounts/{accountNumber}/balance-snapshots");
        return JsonConvert.DeserializeObject<AccountBalanceResponse>(response);
    }
    public async Task<FuturesResponse> GetAllFutures()
    {
        var response = await Get($"{_baseUrl}/instruments/futures");
        return JsonConvert.DeserializeObject<FuturesResponse>(response);
    }
    public async Task<FutureOptionProductsResponse> GetAllFutureOptionProducts()
    {
        var response = await Get($"{_baseUrl}/instruments/future-option-products");
        return JsonConvert.DeserializeObject<FutureOptionProductsResponse>(response);
    }
    public async Task<FuturesContractResponse> GetFuturesContract(string symbol)
    {
        var response = await Get($"{_baseUrl}/instruments/futures/{symbol}");
        return JsonConvert.DeserializeObject<FuturesContractResponse>(response);
    }
    public async Task<OptionChainResponse> GetOptionChains(string symbol)
    {
        var response = await Get($"{_baseUrl}/option-chains/{symbol}");
        return JsonConvert.DeserializeObject<OptionChainResponse>(response);
    }
    public async Task<OptionChainResponse> GetFutureOptionChains(string symbol)
    {
        var response = await Get($"{_baseUrl}/futures-option-chains/{symbol}");
        return JsonConvert.DeserializeObject<OptionChainResponse>(response);
    }
    public async Task<TransactionsResponse> GetTransactions(string accountNumber)
    {
        var response = await Get($"{_baseUrl}/accounts/{accountNumber}/transactions");
        return JsonConvert.DeserializeObject<TransactionsResponse>(response);
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
