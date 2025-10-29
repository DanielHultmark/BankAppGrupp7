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
        //OBS! ur backlog: Som bankägare vill jag inte att transaktioner sker
        //direkt när användarna lägger in dem
        //utan i stället var 15:e minut så att vi har kontroll på när de sker.
        //Behöver fixas!




        public Guid Id { get; private set; } //private set, to avoid Id being changed
        public decimal Amount { get; set; }
        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(decimal amount, Account fromAccount, Account toAccount)
        {
            if (amount > fromAccount.Balance)
            {
                throw new InvalidOperationException("Fel. Överstiger kontots saldo.");
            }
            Id = Guid.NewGuid();
            Amount = amount;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Date = DateTime.Now;

            //add method for currency conversion

            fromAccount.Balance -= amount;
            toAccount.Balance += amount;

            BankRegister.AddTransaction(this);
        }
    }
}
