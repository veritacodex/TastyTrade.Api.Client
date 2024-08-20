using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

        var expirationDates = optionChain.Expirations.Select(x => x.ExpirationDate).ToList();
        foreach (var expiration in expirationDates)
        {
            Console.WriteLine(expiration);
        }

        //await File.WriteAllTextAsync("./optionChain.json", JsonConvert.SerializeObject(optionChain));
    }
}