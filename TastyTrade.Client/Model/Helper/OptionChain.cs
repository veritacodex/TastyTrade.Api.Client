using System.Collections.Generic;
using System.Linq;
using TastyTrade.Client.Model.Response;

namespace TastyTrade.Client.Model.Helper;

public class OptionChain
{
    public List<OptionChainExpiration> Expirations { get; }
    public OptionChain(OptionChainResponse response)
    {
        Expirations = [];
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
                    CallStreamerSymbol = strike.FirstOrDefault(x=> x.OptionType == "C").StreamerSymbol,
                    PutStreamerSymbol = strike.FirstOrDefault(x=> x.OptionType == "P").StreamerSymbol
                });
            }
            Expirations.Add(expiration);
        }
    }
}

public class OptionChainExpiration
{
    public string ExpirationDate { get; set; }
    public List<OptionChainExpirationItem> Items { get; set; }
}

public class OptionChainExpirationItem
{
    public double Strike { get; set; }
    public string CallStreamerSymbol { get; set; }
    public double CallBid { get; set; }
    public double CallAsk { get; set; }
    public string PutStreamerSymbol { get; set; }
    public double PutBid { get; set; }
    public double PutAsk { get; set; }
}