using BankAppGrupp7.EconomicsClasses;
using BankAppGrupp7.UsersClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.AccountClasses
{
    public abstract class Account
    {
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public Customer Owner { get; set; }
        public decimal Balance { get; set; }
        public CurrencyCode Currency { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public Account(string accountType, string accountNumber, Customer owner, decimal balance, CurrencyCode currency)
        {
            AccountType = accountType;
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = balance;
            Currency = currency;
        }       
      
    }
    
}
