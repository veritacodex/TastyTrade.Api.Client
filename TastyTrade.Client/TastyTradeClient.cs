using System;

namespace TastyTrade.Client;

public class TastyTradeClient
{
    private readonly string _baseUrl;

    public TastyTradeClient(string baseUrl, string username, string password)
    {
        _baseUrl = baseUrl;
        Authenticate(username, password);
    }

    private void Authenticate(string username, string password)
    {
        throw new NotImplementedException();
    }
}
