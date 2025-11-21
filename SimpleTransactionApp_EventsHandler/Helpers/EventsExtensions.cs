using SimpleTransactionApp_EventsHandler.Models;
using SimpleTransactionApp_EventsHandler.Models.EventModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTransactionApp_EventsHandler.Helpers
{
    public static class EventsExtensions
    {
        public static EventHandler<DepositEventArgs> DepositEvent(this Transaction transaction)
        {
            EventHandler<DepositEventArgs> handler = (sender, e) =>
            {
                transaction.Amount += e.Value;
                Console.WriteLine("Deposit amount: " + e.Value);
                Console.WriteLine("After deposit value: " + transaction.Amount);
            };

            return handler;
        }
        
        public static EventHandler<WithdrawEventArgs> WithdrawEvent(this Transaction transaction)
        {
            EventHandler<WithdrawEventArgs> handler = (sender, e) =>
            {
                transaction.Amount -= e.Value;
                Console.WriteLine("Deposit amount: " + e.Value);
                Console.WriteLine("After withdraw value: " + transaction.Amount);
            };

            return handler;
        }
    }
}
