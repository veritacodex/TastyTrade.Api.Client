using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TastyTrade.Client.Model.Response.Streaming;

namespace TastyTrade.Client.Model.Helper
{
    public enum AccountDataUpdatesConnectionStatus { 
        Unknown = 0,
        Open = 1,
        Fault = 2,
        Closed = 3
    }
    public class AccountDataUpdates
    {

        public DateTime ConnectionOpened { get; set; }
        public DateTime LastHeartbeatReceived { get; set; }
        public DateTime LastOrderUpdateReceived { get; set; }
        public AccountDataUpdatesConnectionStatus ConnectionStatus { get; set; }
        public Queue<StreamingAccountOrderUpdate> OrderUpdates { get; internal set; }

        public AccountDataUpdates() { 
            this.OrderUpdates = new Queue<StreamingAccountOrderUpdate>();
        }
    }
}
