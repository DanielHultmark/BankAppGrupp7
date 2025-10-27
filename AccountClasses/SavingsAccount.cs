using System;
using System.Collections.Generic;
using BankAppGrupp7.EconomicsClasses; 

namespace BankAppGrupp7.AccountClasses
{
    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; set; }

        public SavingsAccount(string accountNumber, Customer owner, decimal balance, Currency currency)
            : base(accountNumber, owner, balance, currency)
        {            
            IntrestRate = 1.005M;
        }

        public override void Deposit(decimal amount)
        {
            Balance += amount;
            new Transaction((decimal)amount, this, this); 
        }

        public override void Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                new Transaction((double)amount, this, this);
            }
            else
            {
                Console.WriteLine("Otillräckligt saldo.");
            }
        }
    }
}
