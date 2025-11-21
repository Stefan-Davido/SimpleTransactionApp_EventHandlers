namespace SimpleTransactionApp_EventsHandler.Models.EventModels
{
    public class WithdrawEventArgs : EventArgs
    {
        public int Value { get; set; }

        public WithdrawEventArgs(int amount)
        {
            Value = amount;
        }

        public WithdrawEventArgs() { }
    }
}
