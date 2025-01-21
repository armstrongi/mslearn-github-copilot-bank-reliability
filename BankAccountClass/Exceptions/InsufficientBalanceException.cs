using System;

namespace BankAccountApp.Exceptions
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException() : base("Insufficient balance for debit.") { }
    }
}