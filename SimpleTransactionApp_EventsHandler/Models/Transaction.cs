using SimpleTransactionApp_EventsHandler.Models.EventModels;

namespace SimpleTransactionApp_EventsHandler.Models
{
    public class Transaction
    {
        // code can subscribe/unsubscribe via += and -=
        public event EventHandler<DepositEventArgs> DepositOnChange;
        public event EventHandler<WithdrawEventArgs> WithdrawOnChange;

        public int Amount { get; set; }

        // *** create event args and raise the event
        public void Deposit(int value)
        {
            var args = new DepositEventArgs(value);
            OnDepositChanged(args);
        }

        // *** create event args and raise the event
        public void Withdraw(int value)
        {
            var args = new WithdrawEventArgs(value);
            OnWithdrawChanged(args);
        }

        // *** rotected virtual raiser methods (standard pattern)
        protected virtual void OnDepositChanged(DepositEventArgs e)
        {
            DepositOnChange?.Invoke(this, e);
        }

        protected virtual void OnWithdrawChanged(WithdrawEventArgs e)
        {
            WithdrawOnChange?.Invoke(this, e);
        }
    }
}
