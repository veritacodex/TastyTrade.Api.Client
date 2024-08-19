using System.Threading;
using System.Threading.Tasks;
using DxFeed.Graal.Net;

namespace TastyTrade.Client.Examples;

static class Program
{
    static async Task Main()
    {
        SystemProperty.SetProperty("dxfeed.experimental.dxlink.enable", "true");
        SystemProperty.SetProperty("scheme", "ext:opt:sysprops,resource:dxlink.xml");
        
        await OptionChainStreamer.Run();
        await Task.Delay(Timeout.Infinite);
    }
}