using BankAppGrupp7.EconomicsClasses;
using BankAppGrupp7.UsersClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankAppGrupp7.AccountClasses
{
    internal class Account
    {
        public abstract class Account
        {
            public string AccountNumber { get; set; }
            public Customer Owner { get; set; }
            public decimal Balance { get; set; }
            public Currency Currency { get; set; }
            public List<Transaction> Transactions { get; set; } = new List<Transaction>();

            public Account(string accountNumber, Customer owner, decimal balance, Currency currency)
            {
                AccountNumber = accountNumber;
                Owner = owner;
                Balance = balance;
                Currency = currency;
            }

            public void ShowBalance()
            {
                Console.WriteLine($"Saldo för konto {AccountNumber}: {Balance} {Currency}");
            }

            public abstract void Deposit(decimal amount);
            public abstract void Withdraw(decimal amount);
        }
    }
}
