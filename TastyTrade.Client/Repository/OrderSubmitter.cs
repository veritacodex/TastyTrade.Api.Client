using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using TastyTrade.Client.Model.Request;

namespace TastyTrade.Client.Repository
{
    public static class OrderSubmitter
    {
        

        public static async Task Run( AuthorizationCredentials credentials, PlaceOrderRequest orderSubmission)
        {
            var tastyTradeClient = new TastyTradeClient();
            await tastyTradeClient.Authenticate(credentials);
            await tastyTradeClient.PostOrderSubmission(credentials.AccountNumber, orderSubmission);
        }
    }
}