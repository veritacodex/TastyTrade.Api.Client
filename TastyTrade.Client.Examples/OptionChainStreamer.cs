using System.IO;
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
        var optionChainsResponse = await tastyTradeClient.GetOptionChains("SPY");
        var optionChain = new OptionChain(underlying, optionChainsResponse);
        await File.WriteAllTextAsync("./optionChain.json", JsonConvert.SerializeObject(optionChain));
    }
}