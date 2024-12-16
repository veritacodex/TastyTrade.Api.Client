using System.Threading.Tasks;
using TastyTrade.Client.Model.Request;
using TastyTrade.Client.Model.Response;

namespace TastyTrade.Client.Model.Helper
{
    public static class OrderSubmitter
    {
        public static async Task<PlacedOrderResponse> Run(AuthorizationCredentials credentials, PlaceOrderRequest orderSubmission)
        {
            var tastyTradeClient = new TastyTradeClient();
            await tastyTradeClient.Authenticate(credentials);
            return await tastyTradeClient.PostOrderSubmission(credentials.AccountNumber, orderSubmission);
        }
    }
}