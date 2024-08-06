using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DxFeed.Graal.Net;
using DxFeed.Graal.Net.Api;
using DxFeed.Graal.Net.Events.Market;
using Newtonsoft.Json;
using TastyTrade.Client.Model.Request;

namespace TastyTrade.Client.Examples;

static class Program
{
    static async Task Main()
    {
        var credentials = JsonConvert.DeserializeObject<AuthorizationCredentials>(await File.ReadAllTextAsync("./credentials.json"));
        var tastyTradeClient = new TastyTradeClient();
        await tastyTradeClient.Authenticate(credentials);
        var apiQuoteTokens = await tastyTradeClient.GetApiQuoteTokens();

        var symbol = "AAPL";
        SystemProperty.SetProperty("dxfeed.experimental.dxlink.enable", "true");
        SystemProperty.SetProperty("scheme", "ext:opt:sysprops,resource:dxlink.xml");
        var address = $"dxlink:wss://{apiQuoteTokens.Data.DxlinkUrl.Replace("wss://", string.Empty)}[login=dxlink:{apiQuoteTokens.Data.Token}]";
        var sub = DXEndpoint.GetInstance().Connect(address).GetFeed().CreateSubscription(typeof(Quote));
        sub.AddEventListener(events =>
        {
            foreach (var quote in events)
            {
                Console.WriteLine(quote);
            }
        });
        sub.AddSymbols(symbol);
        await Task.Delay(Timeout.Infinite);
    }
}
