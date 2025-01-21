using System;

namespace BankAccountApp.Exceptions
{
    public class TransferLimitExceededException : Exception
    {
        public TransferLimitExceededException() : base("Transfer amount exceeds maximum limit for different account owners.") { }
    }
}