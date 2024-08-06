using System;
using System.IO;
using System.Threading.Tasks;
using DxFeed.Graal.Net;
using DxFeed.Graal.Net.Api;
using DxFeed.Graal.Net.Events.Market;
using Newtonsoft.Json;
using TastyTrade.Client.Model.Request;

namespace TastyTrade.Client.Examples;

public class FuturesStreamer
{
    public static async Task Run(){

        SystemProperty.SetProperty("dxfeed.experimental.dxlink.enable", "true");
        SystemProperty.SetProperty("scheme", "ext:opt:sysprops,resource:dxlink.xml");

        var credentials = JsonConvert.DeserializeObject<AuthorizationCredentials>(await File.ReadAllTextAsync("./credentials.json"));
        var tastyTradeClient = new TastyTradeClient();
        await tastyTradeClient.Authenticate(credentials);
        var es = await tastyTradeClient.GetFuturesContract("ESU4");
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
