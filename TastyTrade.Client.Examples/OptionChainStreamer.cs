using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DxFeed.Graal.Net.Api;
using DxFeed.Graal.Net.Events.Market;
using DxFeed.Graal.Net.Events.Options;
using Newtonsoft.Json;
using TastyTrade.Client.Model.Helper;
using TastyTrade.Client.Model.Request;

namespace TastyTrade.Client.Examples;

public static class OptionChainStreamer
{
    private static OptionChain _optionChain;

    public static async Task Run()
    {
        var credentials = JsonConvert.DeserializeObject<AuthorizationCredentials>(await File.ReadAllTextAsync("./credentials.json"));
        var tastyTradeClient = new TastyTradeClient();
        await tastyTradeClient.Authenticate(credentials);

        string symbol = "AAPL";
        var underlying = await tastyTradeClient.GetEquity(symbol);
        var optionChainsResponse = await tastyTradeClient.GetOptionChains(symbol);

        _optionChain = new OptionChain(underlying, optionChainsResponse);
        _optionChain.SelectNextExpiration();

        var apiQuoteTokens = await tastyTradeClient.GetApiQuoteTokens();
        var address = $"dxlink:{apiQuoteTokens.Data.DxlinkUrl}[login=dxlink:{apiQuoteTokens.Data.Token}]";
        var feed = DXEndpoint.GetInstance().Connect(address).GetFeed();
        var quotes = feed.CreateSubscription(typeof(Quote));
        var greeks = feed.CreateSubscription(typeof(Greeks));

        quotes.AddEventListener(events =>
        {
            foreach (var ev in events)
            {
                if (ev is Quote quote)
                {
                    _optionChain.UpdateQuote((Quote)ev);
                }
            }
        });
        quotes.AddSymbols(_optionChain.Underlying.StreamerSymbol);
        foreach (var expiration in _optionChain.Expirations.First().Items)
        {
            quotes.AddSymbols(expiration.Call.StreamerSymbol);
            quotes.AddSymbols(expiration.Put.StreamerSymbol);
        }

        greeks.AddEventListener(events =>
        {
            foreach (var ev in events)
            {
                if (ev is Greeks greeks)
                {
                    _optionChain.UpdateGreeks((Greeks)ev);
                }
            }
        });
        foreach (var expiration in _optionChain.Expirations.First().Items)
        {
            greeks.AddSymbols(expiration.Call.StreamerSymbol);
            greeks.AddSymbols(expiration.Put.StreamerSymbol);
        }
    }
}