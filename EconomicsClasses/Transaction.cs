using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.EconomicsClasses
{
    internal class Transaction
    {

        public Guid Id { get; private set; } //private set to avoid Id being changed
        public double Amount { get; set; }
        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }
        public DateTime Date { get; set; }
        public static List<Transaction> AllTransactions { get; set; }



        public Transaction(double amount, Account fromAccount, Account toAccount)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Date = DateTime.Now;

            //add if-statement for currency conversion

            fromAccount.Balance -= amount;
            toAccount.Balance += amount;


            toAccount.Transactions.Add(this);
            fromAccount.Transactions.Add(this);
            AllTransactions.Add(this);

        }

    }
}
