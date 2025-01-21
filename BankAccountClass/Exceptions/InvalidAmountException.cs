using System;

namespace BankAccountApp.Exceptions
{
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException() : base("Amount must be positive.") { }
    }
}