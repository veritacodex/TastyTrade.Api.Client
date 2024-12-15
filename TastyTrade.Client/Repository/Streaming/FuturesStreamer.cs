using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using DxFeed.Graal.Net.Api;
using DxFeed.Graal.Net.Events.Market;
using TastyTrade.Client.Model.Request;
using TastyTrade.Client.Repository;

namespace TastyTrade.Client.Examples;

public static class FuturesStreamer
{
    public static async Task Run(AuthorizationCredentials credentials, string futureSymbol)
    {

        
        var tastyTradeClient = new TastyTradeClient();
        await tastyTradeClient.Authenticate(credentials);
        var es = await tastyTradeClient.GetFuturesContract(futureSymbol);
        var apiQuoteTokens = await tastyTradeClient.GetApiQuoteTokens();
        var address = $"dxlink:{apiQuoteTokens.Data.DxlinkUrl}[login=dxlink:{apiQuoteTokens.Data.Token}]";
        var sub = DXEndpoint.GetInstance().Connect(address).GetFeed().CreateSubscription(typeof(Quote));
        
        sub.AddEventListener(events =>
        {
            foreach (var ev in events)
            {
                if (ev is Quote quote)
                {
                    Console.WriteLine($"BidPrice:{quote.BidPrice} AskPrice:{quote.AskPrice}");
                }
            }
        });

        sub.AddSymbols(es.Contract.StreamerSymbol);
    }
}
