using BankAppGrupp7.AccountClasses;
using BankAppGrupp7.MenuClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.EconomicsClasses
{
    public class Transaction
    {
        BankRegister BankRegister = new BankRegister();

        public Guid Id { get; private set; } //private set, to avoid Id being changed
        public decimal Amount { get; set; }
        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(decimal amount, Account fromAccount, Account toAccount)
        {

            Id = Guid.NewGuid();
            Amount = amount;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Date = DateTime.Now;


        }
        
    }
   
}
