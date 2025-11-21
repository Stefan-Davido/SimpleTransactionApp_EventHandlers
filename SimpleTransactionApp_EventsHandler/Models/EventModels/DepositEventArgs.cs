namespace SimpleTransactionApp_EventsHandler.Models.EventModels
{
    public class DepositEventArgs : EventArgs
    {
        public int Value { get; set; }

        public DepositEventArgs(int amount)
        {
            Value = amount;
        }

        public DepositEventArgs() { }
    }
}
