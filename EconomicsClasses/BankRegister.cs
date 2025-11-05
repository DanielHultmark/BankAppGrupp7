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
        public static List<Account> AllAccounts { get; set; } = new List<Account>();
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

// public void Withdraw(decimal amount)
//        {
//            if (amount > 0 && amount <= Balance)
//            {
//                Balance -= amount;
//                new Transaction(amount, this, this);
//            }
//        }

// public void DepositSalary(decimal salaryAmount)
//        {
//            if (salaryAmount > 0)
//            {
//                Balance += salaryAmount;
//                new Transaction(salaryAmount, this, this);
//            }
//        }

//public void DepositSalary(decimal salaryAmount)
// {
//     if (salaryAmount > 0)
//     {
//         Balance += salaryAmount;
//         new Transaction(salaryAmount, this, this);
//     }
// }
