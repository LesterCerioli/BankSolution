using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank.Domain.Models
{
    public class BankAccount : Entity, IAggregateRoot
    {
        private string _accountNumber;

        public string AccountNumber
        {
            get { return _accountNumber; }
            private set
            {
                if (IsValidAccountNumber(value))
                {
                    _accountNumber = value;
                }
                else
                {
                    throw new ArgumentException("Invalid account number. Account number must contain 9 digits in the format xxxxxxxx-x.");
                }
            }
        }

        public Customer Customer { get; private set; }

        public BankAccount(string accountNumber, Customer customer )
        {
            AccountNumber = accountNumber;
            Customer = customer;
        }

        private bool IsValidAccountNumber(string accountNumber)
        {
            // Remove any non-digit characters
            accountNumber = Regex.Replace(accountNumber, @"[^0-9]", "");

            // Check if the account number has 9 digits and a hyphen in the correct position
            return Regex.IsMatch(accountNumber, @"^\d{8}-\d$");
        }


    }
}
