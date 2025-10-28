using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.EconomicsClasses
{
    internal static class BankRegister
    {
        public static List<Transaction> AllTransactions { get; set; } 
        public static List<Loan> AllLoans { get; set; }
        public static List<Account> AllAccounts { get; set; }

        public static void AddTransaction(Transaction t)
        {
            AllTransactions.Add(t);
        }
        public static void AddLoan(Loan l)
        {
            AllLoans.Add(l);
        }

        public static void AddAccount(Account a)
        {
            AllAccounts.Add(a);
        }
    }
}
