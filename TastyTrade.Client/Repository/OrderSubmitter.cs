using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using TastyTrade.Client.Model.Request;

namespace TastyTrade.Client.Repository
{
    public static class OrderSubmitter
    {
        
        public static async Task Run() {
            var credentials = JsonSerializer.Deserialize<AuthorizationCredentials>(await File.ReadAllTextAsync(RepositoryConstants.DefaultCredentialsPath));
            await Run( credentials );
        }

        public static async Task Run( AuthorizationCredentials credentials )
        {
            var tastyTradeClient = new TastyTradeClient();
            await tastyTradeClient.Authenticate(credentials);

            var orderSubmission = new PlaceOrderRequest()
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

            await tastyTradeClient.PostOrderSubmission(credentials.AccountNumber, orderSubmission);
        }
    }
}