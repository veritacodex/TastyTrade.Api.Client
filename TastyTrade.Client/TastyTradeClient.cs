using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using TastyTrade.Client.Model;
using TastyTrade.Client.Model.Request;
using TastyTrade.Client.Model.Response;

namespace TastyTrade.Client;

public class TastyTradeClient
{
    private AuthenticationResponse _authenticationResponse;
    private string _userAgent;
    private string _baseUrl;

    public async Task Authenticate(AuthorizationCredentials credentials)
    {
        _userAgent = credentials.UserAgent;
        _baseUrl = credentials.ApiBaseUrl;

        using var client = new HttpClient();
        client.DefaultRequestHeaders.UserAgent.ParseAdd(credentials.UserAgent);
        using var content = new StringContent(JsonSerializer.Serialize(credentials));
        content.Headers.ContentType = new MediaTypeHeaderValue(Constants.ContentType);
        var response = await client.PostAsync($"{_baseUrl}/sessions", content);
        var responseJson = await response.Content.ReadAsStringAsync();
        _authenticationResponse = JsonSerializer.Deserialize<AuthenticationResponse>(responseJson);
    }
    public async Task<CustomerResponse> GetCustomer()
    {
        var response = await Get($"{_baseUrl}/customers/me");
        return JsonSerializer.Deserialize<CustomerResponse>(response);
    }
    public async Task<ApiQuoteTokenResponse> GetApiQuoteTokens()
    {
        var response = await Get($"{_baseUrl}/api-quote-tokens");
        return JsonSerializer.Deserialize<ApiQuoteTokenResponse>(response);
    }
    public async Task<AccountsResponse> GetAccounts()
    {
        var response = await Get($"{_baseUrl}/customers/me/accounts");
        return JsonSerializer.Deserialize<AccountsResponse>(response);
    }
    public async Task<AccountResponse> GetAccount(string accountNumber)
    {
        var response = await Get($"{_baseUrl}/customers/me/accounts/{accountNumber}");
        return JsonSerializer.Deserialize<AccountResponse>(response);
    }
    public async Task<TradingStatusResponse> GetAccountStatus(string accountNumber)
    {
        var response = await Get($"{_baseUrl}/accounts/{accountNumber}/trading-status");
        return JsonSerializer.Deserialize<TradingStatusResponse>(response);
    }
    public async Task<AccountBalanceResponse> GetAccountBalance(string accountNumber)
    {
        var response = await Get($"{_baseUrl}/accounts/{accountNumber}/balances");
        return JsonSerializer.Deserialize<AccountBalanceResponse>(response);
    }
    public async Task<AccountBalanceResponse> GetAccountBalance(string accountNumber, string currency)
    {
        var response = await Get($"{_baseUrl}/accounts/{accountNumber}/balances/{currency}");
        return JsonSerializer.Deserialize<AccountBalanceResponse>(response);
    }
    public async Task<AccountBalanceResponse> GetAccountBalanceSnapshot(string accountNumber)
    {
        var response = await Get($"{_baseUrl}/accounts/{accountNumber}/balance-snapshots");
        return JsonSerializer.Deserialize<AccountBalanceResponse>(response);
    }
    public async Task<FutureContractsResponse> GetAllFutures()
    {
        var response = await Get($"{_baseUrl}/instruments/futures");
        return JsonSerializer.Deserialize<FutureContractsResponse>(response);
    }
    public async Task<FutureOptionProductsResponse> GetAllFutureOptionProducts()
    {
        var response = await Get($"{_baseUrl}/instruments/future-option-products");
        return JsonSerializer.Deserialize<FutureOptionProductsResponse>(response);
    }
    public async Task<FutureOptionProductResponse> GetFutureOptionProduct(string exchange, string symbol)
    {
        var response = await Get($"{_baseUrl}/instruments/future-option-products/{exchange}/{symbol}");
        return JsonSerializer.Deserialize<FutureOptionProductResponse>(response);
    }
    public async Task<FutureContractResponse> GetFuturesContract(string symbol)
    {
        var response = await Get($"{_baseUrl}/instruments/futures/{symbol}");
        return JsonSerializer.Deserialize<FutureContractResponse>(response);
    }
    public async Task<SearchResponse> Search(string symbol)
    {
        //this method seemed to be unavalaible at the time I added it.
        var response = await Get($"{_baseUrl}/symbols/search/{symbol}");
        return JsonSerializer.Deserialize<SearchResponse>(response);
    }
    public async Task<OptionChainResponse> GetOptionChains(string symbol)
    {
        var response = await Get($"{_baseUrl}/option-chains/{symbol}");
        var chain = JsonSerializer.Deserialize<OptionChainResponse>(response);
        chain.Data.Items = [.. chain.Data.Items.Where(x => x.Active).OrderBy(x => x.StrikePrice)];
        return chain;
    }
    public async Task<OptionChainResponse> GetFutureOptionChains(string symbol)
    {
        var response = await Get($"{_baseUrl}/futures-option-chains/{symbol}");
        var chain = JsonSerializer.Deserialize<OptionChainResponse>(response);
        chain.Data.Items = [.. chain.Data.Items.Where(x => x.Active).OrderBy(x => x.StrikePrice)];
        return chain;
    }
    public async Task<TransactionsResponse> GetTransactions(string accountNumber)
    {
        var response = await Get($"{_baseUrl}/accounts/{accountNumber}/transactions");
        return JsonSerializer.Deserialize<TransactionsResponse>(response);
    }
    public async Task<EquityResponse> GetEquity(string symbol)
    {
        var response = await Get($"{_baseUrl}/instruments/equities/{symbol}");
        return JsonSerializer.Deserialize<EquityResponse>(response);
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
    private async Task<string> Post(string url, string jsonBody)
    {
        var uri = new Uri(url);
        using var client = new HttpClient();
        client.DefaultRequestHeaders.UserAgent.ParseAdd(_userAgent);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.Accept));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_authenticationResponse.Data.SessionToken);

        using var content = new StringContent( jsonBody );
        content.Headers.ContentType = new MediaTypeHeaderValue(Constants.ContentType);

        var response = await client.PostAsync(uri, content);
        if ((!response.IsSuccessStatusCode) && (response.StatusCode != HttpStatusCode.UnprocessableEntity))
        {
            var errorResponseTextIfAny = await response.Content.ReadAsStringAsync();
            throw new InvalidOperationException($"{uri.PathAndQuery} - {response.StatusCode.ToString()}-{response.ReasonPhrase}", new InvalidOperationException(errorResponseTextIfAny));
        }
        var responseText = await response.Content.ReadAsStringAsync();
        return responseText;
    }

    private async Task<ResponseType> Post<RequestType, ResponseType>(string url, RequestType requestBodyObject) 
        where RequestType : new()
        where ResponseType : new() 
    {

        var requestBodyJson = JsonSerializer.Serialize(requestBodyObject);
        var responseJson = await Post(url, requestBodyJson);

        var responseType = JsonSerializer.Deserialize<ResponseType>(responseJson);

        return responseType;
    }


    public async Task<PlacedOrderResponse> PostOrderSubmission(string accountNumber, PlaceOrderRequest orderSubmission) {
        var orderSubmissionResponse = await Post<PlaceOrderRequest, PlacedOrderResponse> ($"{_baseUrl}/accounts/{accountNumber}/orders", orderSubmission);
        return orderSubmissionResponse;
    }
}
