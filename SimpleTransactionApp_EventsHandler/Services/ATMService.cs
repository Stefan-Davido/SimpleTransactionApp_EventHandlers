using SimpleTransactionApp_EventsHandler.Helpers;
using SimpleTransactionApp_EventsHandler.Models;

namespace SimpleTransactionApp_EventsHandler.Services
{
    public class ATMService
    {
        public static ATMSessionType StartingtPoint(Transaction transaction)
        {
            DisplayOptions();
            var numberSelection = ParseSelectedOption();
            ATMSessionType atmSessionType = ATMSessionType.None;

            switch (numberSelection)
            {
                case 1:
                    Console.WriteLine("Deposit selected");
                    HandleDeposit(transaction);
                    atmSessionType = ATMSessionType.Deposit;
                    break;
                case 2:
                    Console.WriteLine("Withdraw selected");
                    HandleWithdraw(transaction);
                    atmSessionType = ATMSessionType.Withdraw;
                    break;
                case 3:
                    Console.WriteLine("Balance selected");
                    Balance(transaction);
                    atmSessionType = ATMSessionType.Balance;
                    break;
                case 4:
                    atmSessionType = ATMSessionType.Exit;
                    Console.WriteLine("Exit");
                    break;
                default:
                    Console.WriteLine("Please select again");
                    atmSessionType = ATMSessionType.None;
                    break;
            };


            return atmSessionType;
        }

        public static int ParseSelectedOption()
        {
            int number;
            int retries = 0;

            while (true)
            {
                Console.Write("Enter a number: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out number))
                    break;

                Console.WriteLine("Invalid input. Please enter a valid number.");
                retries += 1;

                if (retries >= 3)
                {
                    Console.WriteLine("You reached maximum retries. You account is now blocked");
                    throw new Exception("You are blocked");
                }
            }

            Console.WriteLine($"You entered: {number}");

            return number;
        }

        public static void HandleDeposit(Transaction transaction)
        {
            // *** enter amount
            var parsedAmount = ParseAmountOption("deposit");

            // *** create event
            var deposit = transaction.DepositEvent();
            transaction.DepositOnChange += deposit;

            // *** process deposit event
            transaction.Deposit(parsedAmount);
            transaction.DepositOnChange -= deposit;
        }

        public static void HandleWithdraw(Transaction transaction)
        {
            // *** enter amount
            var parsedAmount = ParseAmountOption("withdraw");

            if (!CanWithdrawAmount(transaction, parsedAmount))
            {
                Console.WriteLine("You cant withdraw this amount from your account!");
                return;
            }

            // *** create event
            var deposit = transaction.WithdrawEvent();
            transaction.WithdrawOnChange += deposit;

            // *** process withdraw event
            transaction.Withdraw(parsedAmount);
            transaction.WithdrawOnChange -= deposit;
        }

        private static int ParseAmountOption(string option)
        {
            int amount;
            int retries = 0;

            while (true)
            {
                Console.Write($"Enter the amount you want to {option}: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out amount))
                    break;

                Console.WriteLine("Invalid input. Please enter a valid number.");
                retries += 1;

                if (retries >= 3)
                {
                    Console.WriteLine("You reached maximum retries. Your account is now blocked!");
                    throw new Exception("You are blocked");
                }
            }

            Console.WriteLine($"You entered: {amount}");

            return amount;
        }

        public static void Balance(Transaction transaction)
        {
            Console.WriteLine($"Transaction amount: {transaction.Amount}");
        }

        private static bool CanWithdrawAmount(Transaction transaction, int amount)
        {
            return amount <= transaction.Amount;
        }

        private static void DisplayOptions()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1) Deposit");
            Console.WriteLine("2) Withdraw");
            Console.WriteLine("3) Balance");
            Console.WriteLine("4) Exit");
        }
    }
}
