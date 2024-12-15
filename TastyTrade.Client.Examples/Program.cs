using System;
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

        await FuturesStreamer.Run(credentials, GetTestFuturesSymbol());
        await OptionChainStreamer.Run(credentials, GetTestOptionUnderlyingSymbol(), GetTestOptionExpirationOnOrAfter());
        //await OrderSubmitter.Run(credentials, GetOrderSubmission());  //places an actual order

        await Task.Delay(Timeout.Infinite);
    }


    public static PlaceOrderRequest GetTestOrderSubmission()
    {
        return new PlaceOrderRequest()
        {
            OrderType = OrderType.Limit,
            Price = 26.5m,
            PriceEffect = PriceEffect.Debit,
            TimeInForce = TimeInForce.Day,
            Legs = [
                        new OrderSubmissionLeg(){
                        Action = OrderLegAction.BuyToOpen,
                        InstrumentType = InstrumentType.Equity,
                        Symbol = "GLD",
                        Quantity = 10
                    }
                    ]
        };
    }

    public static string GetTestFuturesSymbol()
    {
        return "ESU4";
    }

    public static string GetTestOptionUnderlyingSymbol() {
        string symbol = "AAPL";
        return symbol;
    }

    public static DateTime GetTestOptionExpirationOnOrAfter()
    {
        return DateTime.Now;
    }
}