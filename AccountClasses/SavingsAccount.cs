using BankAppGrupp7.EconomicsClasses;
using BankAppGrupp7.UsersClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static BankAppGrupp7.AccountClasses.Account;

namespace BankAppGrupp7.AccountClasses
{
    //public class SavingsAccount : Account
    //{
        
        
    //        public decimal InterestRate { get; set; }

    //        public SavingsAccount(string accountNumber, Customer owner, decimal balance, Currency currency)
    //            : base(accountNumber, owner, balance, currency)
    //        {
    //            InterestRate = 1.005M;
    //        }

    //        public override void Deposit(decimal amount)
    //        {
    //            Balance += amount;
    //            new Transaction((decimal)amount, this, this);
    //        }

    //        public override void Withdraw(decimal amount)
    //        {
    //            if (amount <= Balance)
    //            {
    //                Balance -= amount;
    //                new Transaction((double)amount, this, this);
    //            }
    //            else
    //            {
    //                Console.WriteLine("Otillräckligt saldo.");
    //            }
    //        }
    //    }
}
