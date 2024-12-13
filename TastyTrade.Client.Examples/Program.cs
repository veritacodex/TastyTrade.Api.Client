using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DxFeed.Graal.Net;
using TastyTrade.Client.Model.Request;
using TastyTrade.Client.Repository;

namespace TastyTrade.Client.Examples;

static class Program
{
    internal const string CredsPath = "./credentials.json";

    static async Task Main()
    {
        SystemProperty.SetProperty("dxfeed.experimental.dxlink.enable", "true");
        SystemProperty.SetProperty("scheme", "ext:opt:sysprops,resource:dxlink.xml");

        var credentials = JsonSerializer.Deserialize<AuthorizationCredentials>(await File.ReadAllTextAsync(CredsPath));
        await OptionChainStreamer.Run(credentials);
        await Task.Delay(Timeout.Infinite);
    }
}