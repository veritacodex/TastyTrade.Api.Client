using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TastyTrade.Client.Model.Request;

namespace TastyTrade.Client.Examples
{
    public class OrderSubmitter
    {
        public static async Task Run(string accountNumber)
        {
            var credentials = JsonConvert.DeserializeObject<AuthorizationCredentials>(await File.ReadAllTextAsync(Program.CredsPath));
            var tastyTradeClient = new TastyTradeClient();
            await tastyTradeClient.Authenticate(credentials);

            var orderSubmission = new PlaceOrderRequest() { 
                OrderType = OrderType.Limit,
                Price = 26.5m, 
                PriceEffect = PriceEffect.Debit,
                TimeInForce = TimeInForce.Day,
                Legs = new List<OrderSubmissionLeg>() { 
                    new OrderSubmissionLeg(){ 
                        Action = OrderLegAction.BuyToOpen,
                        InstrumentType = InstrumentType.Equity,
                        Symbol = "GLD",
                        Quantity = 10
                    }
                }
            };

            var test = JsonConvert.SerializeObject(orderSubmission);
            var orderSubmissionResponse = await tastyTradeClient.PostOrderSubmission(accountNumber, orderSubmission);
        }
    }
}