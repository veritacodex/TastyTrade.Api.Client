using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TastyTrade.Client.Model.Request;

namespace TastyTrade.Client.Examples;

static class Program
{
    static async Task Main()
    {
        var credentials = JsonConvert.DeserializeObject<AuthorizationCredentials>(await File.ReadAllTextAsync("./credentials.json"));
        var tastyTradeClient = new TastyTradeClient();
        await tastyTradeClient.AuthenticateAsync(credentials);
        var response = await tastyTradeClient.GetAllFutureOptions();
        await File.WriteAllTextAsync("./result.json", JsonConvert.SerializeObject(response));
    }
}
