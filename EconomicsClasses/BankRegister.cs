using BankAppGrupp7.AccountClasses;
using BankAppGrupp7.MenuClasses;
using BankAppGrupp7.UsersClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.EconomicsClasses
{
    public static class BankRegister
    {
        public static List<Transaction> AllTransactions { get; set; } = new List<Transaction>();
        public static List<Loan> AllLoans { get; set; } = new List<Loan>();
        public static List<Account> AllAccounts { get; set; } = new List<Account>() //Setting some default account to make it easier for presentation, the customers doesnt exist in UserList.
        {
            {new SalaryAccount("Lönekonto", "123123123", new Customer("Kattis", "Kattis100", "Katarina Holm"), 25000, CurrencyCode.GBP) },
            {new SavingsAccount("Sparkonto", "123456789", new Customer("Daniel", "Daniel100", "Daniel Hiltmark"), 80000, CurrencyCode.EUR) }
        };

        public static decimal InterestRate { get; private set; } = 2.54m;        

        public static void AddTransaction(Transaction t)
        {
            AllTransactions.Add(t);
        }
        public static void AddLoan(Customer loggedInUser, decimal amount, decimal Interestrate, decimal lenghtOfLoan)
        {
            var loan = new Loan(loggedInUser, amount, Interestrate, lenghtOfLoan);
            AllLoans.Add(loan);
        }

        public static void AddAccount(Account a)
        {
            AllAccounts.Add(a);
        }
        public static Account GetAccountByAccountNumber(string accountNumber)
        {
            return AllAccounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }
    }
}

