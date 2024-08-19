using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TastyTrade.Client.Model.Request;

namespace TastyTrade.Client.Examples;

public static class OptionChainStreamer
{
    public static async Task Run()
    {
        var credentials = JsonConvert.DeserializeObject<AuthorizationCredentials>(await File.ReadAllTextAsync("./credentials.json"));
        var tastyTradeClient = new TastyTradeClient();
        await tastyTradeClient.Authenticate(credentials);
        var customer = await tastyTradeClient.GetCustomer();
        await File.WriteAllTextAsync("./response.json", JsonConvert.SerializeObject(customer));
    }
}