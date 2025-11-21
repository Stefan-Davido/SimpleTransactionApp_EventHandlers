// See https://aka.ms/new-console-template for more information
using SimpleTransactionApp_EventsHandler.Models;
using SimpleTransactionApp_EventsHandler.Services;

Console.WriteLine("Welcome to you ATM!");

var transaction = new Transaction { Amount = 1000 };

ATMSessionType sessionType = ATMSessionType.Start;

while(sessionType != ATMSessionType.None && sessionType != ATMSessionType.Exit)
{
    sessionType = ATMService.StartingtPoint(transaction);
}

Console.WriteLine($"Final transaction amount: {transaction.Amount}");

Console.WriteLine("Press any key to exit...");
Console.ReadKey();