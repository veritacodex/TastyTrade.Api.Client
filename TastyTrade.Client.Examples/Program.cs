using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TastyTrade.Client.Model.Request;

namespace TastyTrade.Client.Examples;

class Program
{
    static async Task Main()
    {
        var credentials = JsonConvert.DeserializeObject<AuthorizationCredentials>(File.ReadAllText("./credentials.json"));
        var tastyTradeClient = new TastyTradeClient();
        var authenticationResponse = await tastyTradeClient.AuthenticateAsync(credentials);
    }
}
