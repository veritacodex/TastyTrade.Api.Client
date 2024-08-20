using System;
using System.IO;
using System.Threading.Tasks;
using DxFeed.Graal.Net.Api;
using DxFeed.Graal.Net.Events.Market;
using Newtonsoft.Json;
using TastyTrade.Client.Model.Helper;
using TastyTrade.Client.Model.Request;

namespace TastyTrade.Client.Examples;

public static class OptionChainStreamer
{
    public static async Task Run()
    {
        var credentials = JsonConvert.DeserializeObject<AuthorizationCredentials>(await File.ReadAllTextAsync("./credentials.json"));
        var tastyTradeClient = new TastyTradeClient();
        await tastyTradeClient.Authenticate(credentials);

        string symbol = "SPY";
        var underlying = await tastyTradeClient.GetEquity(symbol);
        var optionChainsResponse = await tastyTradeClient.GetOptionChains(symbol);
        var optionChain = new OptionChain(underlying, optionChainsResponse);
        optionChain.SelectNextExpiration();

        var apiQuoteTokens = await tastyTradeClient.GetApiQuoteTokens();
        var address = $"dxlink:{apiQuoteTokens.Data.DxlinkUrl}[login=dxlink:{apiQuoteTokens.Data.Token}]";
        var sub = DXEndpoint.GetInstance().Connect(address).GetFeed().CreateSubscription(typeof(Quote));

        sub.AddEventListener(events =>
        {
            foreach (var ev in events)
            {
                if (ev is Quote quote)
                {
                    Console.WriteLine($"Symbol: {quote.EventSymbol} BidPrice:{quote.BidPrice} AskPrice:{quote.AskPrice}");
                }
            }
        });
        sub.AddSymbols(optionChain.Underlying.StreamerSymbol);
    }
}