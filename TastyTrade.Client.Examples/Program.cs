using System;
using System.IO;
using System.Security.Cryptography;
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
        await FuturesStreamer.Run();
        await Task.Delay(Timeout.Infinite);
    }
}
