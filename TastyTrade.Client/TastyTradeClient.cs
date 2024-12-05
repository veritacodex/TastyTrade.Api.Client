using System;
using System.Linq;
using System.Net;
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
    private AuthenticationResponse _authenticationResponse;
    private string _userAgent;
    private string _baseUrl;

    public async Task Authenticate(AuthorizationCredentials credentials)
    {
        _userAgent = credentials.UserAgent;
        _baseUrl = credentials.ApiBaseUrl;

        using var client = new HttpClient();
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
    public async Task<FutureContractsResponse> GetAllFutures()
    {
        var response = await Get($"{_baseUrl}/instruments/futures");
        return JsonConvert.DeserializeObject<FutureContractsResponse>(response);
    }
    public async Task<FutureOptionProductsResponse> GetAllFutureOptionProducts()
    {
        var response = await Get($"{_baseUrl}/instruments/future-option-products");
        return JsonConvert.DeserializeObject<FutureOptionProductsResponse>(response);
    }
    public async Task<FutureOptionProductResponse> GetFutureOptionProduct(string exchange, string symbol)
    {
        var response = await Get($"{_baseUrl}/instruments/future-option-products/{exchange}/{symbol}");
        return JsonConvert.DeserializeObject<FutureOptionProductResponse>(response);
    }
    public async Task<FutureContractResponse> GetFuturesContract(string symbol)
    {
        var response = await Get($"{_baseUrl}/instruments/futures/{symbol}");
        return JsonConvert.DeserializeObject<FutureContractResponse>(response);
    }
    public async Task<SearchResponse> Search(string symbol)
    {
        //this method seemed to be unavalaible at the time I added it.
        var response = await Get($"{_baseUrl}/symbols/search/{symbol}");
        return JsonConvert.DeserializeObject<SearchResponse>(response);
    }
    public async Task<OptionChainResponse> GetOptionChains(string symbol)
    {
        var response = await Get($"{_baseUrl}/option-chains/{symbol}");
        var chain = JsonConvert.DeserializeObject<OptionChainResponse>(response);
        chain.Data.Items = [.. chain.Data.Items.Where(x => x.Active).OrderBy(x => x.StrikePrice)];
        return chain;
    }
    public async Task<OptionChainResponse> GetFutureOptionChains(string symbol)
    {
        var response = await Get($"{_baseUrl}/futures-option-chains/{symbol}");
        var chain = JsonConvert.DeserializeObject<OptionChainResponse>(response);
        chain.Data.Items = [.. chain.Data.Items.Where(x => x.Active).OrderBy(x => x.StrikePrice)];
        return chain;
    }
    public async Task<TransactionsResponse> GetTransactions(string accountNumber)
    {
        var response = await Get($"{_baseUrl}/accounts/{accountNumber}/transactions");
        return JsonConvert.DeserializeObject<TransactionsResponse>(response);
    }
    public async Task<EquityResponse> GetEquity(string symbol)
    {
        var response = await Get($"{_baseUrl}/instruments/equities/{symbol}");
        return JsonConvert.DeserializeObject<EquityResponse>(response);
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
            throw new Exception($"{uri.PathAndQuery} - {response.StatusCode.ToString()}-{response.ReasonPhrase}", new Exception(errorResponseTextIfAny));
        }
        var responseText = await response.Content.ReadAsStringAsync();
        return responseText;
    }

    private async Task<ResponseType> Post<RequestType, ResponseType>(string url, RequestType requestBodyObject) 
        where RequestType : new()
        where ResponseType : new() 
    {
        var requestBodyJson = JsonConvert.SerializeObject(requestBodyObject);
        var responseJson = await Post(url, requestBodyJson);
        var responseType = JsonConvert.DeserializeObject<ResponseType>(responseJson);

        return responseType;
    }


    public async Task<PlacedOrderResponse> PostOrderSubmission(string accountNumber, PlaceOrderRequest orderSubmission) {
        var orderSubmissionResponse = await Post<PlaceOrderRequest, PlacedOrderResponse> ($"{_baseUrl}/accounts/{accountNumber}/orders", orderSubmission);
        return orderSubmissionResponse;
    }
}
