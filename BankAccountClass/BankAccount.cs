using BankAccountApp.Exceptions;
using System;

namespace BankAccountApp
{
    public class BankAccount
    {
        public string AccountNumber { get; }
        public double Balance { get; private set; }
        public string AccountHolderName { get; }
        public string AccountType { get; }
        public DateTime DateOpened { get; }

        public BankAccount(string accountNumber, double initialBalance, string accountHolderName, string accountType, DateTime dateOpened)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                throw new ArgumentException("Account number cannot be null or empty.", nameof(accountNumber));
            }

            if (initialBalance < 0)
            {
                throw new ArgumentException("Initial balance cannot be negative.", nameof(initialBalance));
            }

            if (string.IsNullOrWhiteSpace(accountHolderName))
            {
                throw new ArgumentException("Account holder name cannot be null or empty.", nameof(accountHolderName));
            }

            if (string.IsNullOrWhiteSpace(accountType))
            {
                throw new ArgumentException("Account type cannot be null or empty.", nameof(accountType));
            }

            AccountNumber = accountNumber;
            Balance = initialBalance;
            AccountHolderName = accountHolderName;
            AccountType = accountType;
            DateOpened = dateOpened;
        }

        public void Credit(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException();
            }

            Balance += amount;
        }

        public void Debit(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException();
            }

            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                throw new InsufficientBalanceException();
            }
        }

        public double GetBalance()
        {
            return Balance; // Math.Round(balance, 2);
        }

        public void Transfer(BankAccount toAccount, double amount)
        {
            if (toAccount == null)
            {
                throw new ArgumentNullException(nameof(toAccount));
            }

            if (amount <= 0)
            {
                throw new InvalidAmountException();
            }

            if (this == toAccount)
            {
                throw new ArgumentException("Cannot transfer to the same account.", nameof(toAccount));
            }

            if (Balance >= amount)
            {
                if (amount > 500)
                {
                    throw new TransferLimitExceededException();
                }

                Debit(amount);
                toAccount.Credit(amount);
            }
            else
            {
                throw new InsufficientBalanceException();
            }
        }

        public void PrintStatement()
        {
            Console.WriteLine($"Account Number: {AccountNumber}, Balance: {Balance}");
            // Add code here to print recent transactions
        }

        public double CalculateInterest(double interestRate)
        {
            if (interestRate < 0)
            {
                throw new InvalidAmountException();
            }
            
            return Balance * interestRate;
        }
    }
}