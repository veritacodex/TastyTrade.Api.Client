﻿using System.IO;
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
        var customer = await tastyTradeClient.GetCustomer();

    }
}