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
        var optionChainsResponse = await tastyTradeClient.GetOptionChains("SPY");
        var optionChain = new OptionChain(optionChainsResponse);
        await File.WriteAllTextAsync("./response.json", JsonConvert.SerializeObject(optionChainsResponse));
        await File.WriteAllTextAsync("./optionChain.json", JsonConvert.SerializeObject(optionChain));
    }
}