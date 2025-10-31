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
    public class BankRegister
    {
        public List<Transaction> AllTransactions { get; set; }
        public List<Loan> AllLoans { get; set; }
        public List<Account> AllAccounts { get; set; }
        public decimal InterestRate { get; private set; } = 2.54m;

        public BankRegister()
        {
            AllTransactions = new List<Transaction>();
            AllLoans = new List<Loan>();
            AllAccounts = new List<Account>();
        }

        public void AddTransaction(Transaction t)
        {
            AllTransactions.Add(t);
        }
        public void AddLoan(Customer loggedInUser, decimal amount, decimal Interestrate, decimal lenghtOfLoan)
        {
            var loan = new Loan(loggedInUser, amount, Interestrate, lenghtOfLoan);
            AllLoans.Add(loan);
        }

        public void AddAccount(Account a)
        {
            AllAccounts.Add(a);
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
