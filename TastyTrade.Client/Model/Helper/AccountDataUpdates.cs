using System;
using System.Collections.Generic;
using TastyTrade.Client.Model.Response.Streaming;

namespace TastyTrade.Client.Model.Helper
{
    public enum AccountDataUpdatesConnectionStatus
    {
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

        public AccountDataUpdates()
        {
            OrderUpdates = new Queue<StreamingAccountOrderUpdate>();
        }
    }
}
