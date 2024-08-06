using System.Threading;
using System.Threading.Tasks;

namespace TastyTrade.Client.Examples;

static class Program
{
    static async Task Main()
    {
        await FuturesStreamer.Run();
        await Task.Delay(Timeout.Infinite);
    }
}
