using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BankAppGrupp7.AccountClasses;
using BankAppGrupp7.MenuClasses;

namespace BankAppGrupp7.EconomicsClasses
{
    public static class TransactionManager
    {
        static Queue<Transaction> pendingTransactions { get; set; } = new Queue<Transaction>();
        private static Timer? quarterTimer;
        public static void AddPendingTransaction(decimal amount, Account fromAccount, Account toAccount)
        {             
            Transaction pendningTransaction = new Transaction(amount, fromAccount, toAccount);

            pendingTransactions.Enqueue(pendningTransaction);

        }
        
        public static async Task Start() //Method to start the timer that executes every quarter of an hour
        {
            DateTimeOffset now = DateTimeOffset.Now;
            int nextQuarterMinute = ((now.Minute / 15) + 1) * 15;

            if (nextQuarterMinute == 60)
            {
                nextQuarterMinute = 0;
                now = now.AddHours(1);

                if (now.Hour == 0)
                {
                    now.AddDays(1);
                }
            }


            DateTimeOffset nextQuarter = new DateTimeOffset(now.Year, now.Month, now.Day, now.Hour, nextQuarterMinute, 0, now.Offset);

            TimeSpan timeToStartTimer = nextQuarter - DateTimeOffset.Now;

            quarterTimer = new Timer(ExecuteTransactions, null, timeToStartTimer, TimeSpan.FromMinutes(15)); 

        }
               

        public static void ExecuteTransactions(object? state) //Method that executes all pending transactions
        {
            if (pendingTransactions.Count > 0)
            {
                while (pendingTransactions.Count > 0)
                {
                    var transaction = pendingTransactions.Dequeue();
                    BankRegister.AddTransaction(transaction);
                    decimal convertedAmount = CurrencyConversion.ConvertCurrency(transaction.Amount, transaction.FromAccount.Currency, transaction.ToAccount.Currency);

                    transaction.FromAccount.Balance -= transaction.Amount;
                    transaction.ToAccount.Balance += convertedAmount;

                }
            }
        }

    }
}
