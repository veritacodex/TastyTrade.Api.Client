﻿using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using TastyTrade.Client.Model.Request;

namespace TastyTrade.Client.Examples
{
    public class OrderSubmitter
    {
        public static async Task Run()
        {
            var credentials = JsonSerializer.Deserialize<AuthorizationCredentials>(await File.ReadAllTextAsync(Program.CredsPath));
            var tastyTradeClient = new TastyTradeClient();
            await tastyTradeClient.Authenticate(credentials);

            var orderSubmission = new PlaceOrderRequest() { 
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

            var test = JsonSerializer.Serialize(orderSubmission);
            var orderSubmissionResponse = await tastyTradeClient.PostOrderSubmission(credentials.AccountNumber, orderSubmission);
        }
    }
}