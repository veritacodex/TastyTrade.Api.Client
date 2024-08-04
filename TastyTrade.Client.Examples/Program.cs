using System;
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
        var accounts = await tastyTradeClient.GetAccounts();
        var accountNumber = accounts.Data.Items.FirstOrDefault().Account.AccountNumber;
        var response = await tastyTradeClient.GetAccountStatus(accountNumber);
        Console.WriteLine(JsonConvert.SerializeObject(response));
    }
}
