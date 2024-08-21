using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DxFeed.Graal.Net.Events.Market;
using TastyTrade.Client.Model.Response;

namespace TastyTrade.Client.Model.Helper;

public class OptionChain
{
    public DateTime UpdatedOn { get; internal set;}
    public List<OptionChainExpiration> Expirations { get; internal set; }
    public OptionChainUnderlying Underlying { get; internal set; }

    public OptionChain(EquityResponse underlying, OptionChainResponse response)
    {
        Expirations = [];
        Underlying = new OptionChainUnderlying
        {
            Symbol = underlying.Data.Symbol,
            StreamerSymbol = underlying.Data.StreamerSymbol
        };
        SetExpirations(response);
    }

    public OptionChain(FutureContractResponse underlying, OptionChainResponse response)
    {
        Expirations = [];
        Underlying = new OptionChainUnderlying
        {
            Symbol = underlying.Contract.Symbol,
            StreamerSymbol = underlying.Contract.StreamerSymbol
        };
        SetExpirations(response);
    }

    private void SetExpirations(OptionChainResponse response)
    {
        var expirations = response.Data.Items.Where(x => x.Active).GroupBy(x => x.ExpirationDate).OrderBy(x => x.Key);
        foreach (var item in expirations)
        {
            var expiration = new OptionChainExpiration()
            {
                ExpirationDate = item.Key,
                Items = []
            };
            var strikes = item.GroupBy(x => x.StrikePrice).OrderBy(x => x.Key);
            foreach (var strike in strikes)
            {
                expiration.Items.Add(new OptionChainExpirationItem
                {
                    Strike = strike.Key,
                    Call = new OptionChainItemSide
                    {
                        StreamerSymbol = strike.First(x => x.OptionType == "C").StreamerSymbol
                    },
                    Put = new OptionChainItemSide
                    {
                        StreamerSymbol = strike.First(x => x.OptionType == "P").StreamerSymbol
                    }
                });
            }
            Expirations.Add(expiration);
        }
    }

    public void SelectNextExpiration()
    {
        var nextExpirationDate = GetNextExpirationDate();
        Expirations = Expirations.Where(x => x.ExpirationDate == nextExpirationDate).ToList();
    }

    private string GetNextExpirationDate()
    {
        return Expirations.Find(x =>
            (DateTime.ParseExact(x.ExpirationDate, "yyyy-MM-dd", CultureInfo.InvariantCulture) - DateTime.Now).Days > 0)
            .ExpirationDate;
    }

    public void UpdateQuote(Quote quote)
    {
        if (Underlying.Symbol == quote.EventSymbol)
        {
            Underlying.Bid = quote.BidPrice;
            Underlying.Ask = quote.AskPrice;
        }
        else
        {
            foreach (var expiration in Expirations)
            {
                foreach (var item in expiration.Items)
                {
                    if (item.Call.StreamerSymbol == quote.EventSymbol)
                    {
                        item.Call.Bid = quote.BidPrice;
                        item.Call.Ask = quote.AskPrice;
                    }
                    else if (item.Put.StreamerSymbol == quote.EventSymbol)
                    {
                        item.Put.Bid = quote.BidPrice;
                        item.Put.Ask = quote.AskPrice;
                    }
                    item.IsAtTheMoney = item.Strike > Underlying.Bid && item.Strike < Underlying.Ask;
                }
            }
        }
    }
}

public class OptionChainUnderlying
{
    public string StreamerSymbol { get; internal set; }
    public string Symbol { get; internal set; }
    public double Bid { get; set; }
    public double Ask { get; set; }
}

public class OptionChainExpiration
{
    public string ExpirationDate { get; set; }
    public List<OptionChainExpirationItem> Items { get; set; }
}

public class OptionChainExpirationItem
{
    public double Strike { get; set; }
    public OptionChainItemSide Call { get; set; }
    public OptionChainItemSide Put { get; set; }
    public bool IsAtTheMoney { get; set; }
}

public class OptionChainItemSide
{
    public string StreamerSymbol { get; set; }
    public double Bid { get; internal set; }
    public double Ask { get; internal set; }
    public double Delta { get; internal set; }
    public double Gamma { get; internal set; }
    public double Theta { get; internal set; }
    public double Rho { get; internal set; }
    public double Vega { get; internal set; }
}