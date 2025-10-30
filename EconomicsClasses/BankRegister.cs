using BankAppGrupp7.AccountClasses;
using BankAppGrupp7.MenuClasses;
using BankAppGrupp7.UsersClasses;
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
        public static decimal InterestRate { get; private set; } = 2.54m;

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
        public static void ApplyForLoan() //Ansök om lån för en användare
        {

            Customer loggedInUser;

            Console.WriteLine("Hur mycket önskar du att låna?");


            Console.WriteLine("Under hur lånt tid önskar du att betala tillbaka lånet? (Ange antal månader)");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Felatkig inmatning, försök igen!");
                return;
            }
            if (!decimal.TryParse(Console.ReadLine(), out decimal lengthOfLoan))
            {
                Console.WriteLine("Felaktig inmatning, försök igen!");
                return;
            }
            decimal intrest = amount * InterestRate / 100;
            decimal total = amount + InterestRate;
            decimal monthlyPayment = total / lengthOfLoan;
            Console.WriteLine($"Du har ansökt om ett lån på {amount} kr med en ränta på {InterestRate}%. Totalt att återbetala är {total} kr.");
            Loan newLoan = new Loan(loggedInUser, amount, InterestRate, lengthOfLoan);
            //Lägg till lånet i listan över lån

        }
        public static void ViewLoans() //Visa alla lån för en användare
        {
            List<Loan> listOfLoans = new List<Loan>();
            if (listOfLoans.Count == 0)
            {
                Console.WriteLine("Du har inga lån för tillfället.");
                return;
            }
            Console.WriteLine("Dina lån:");
            foreach (var loan in listOfLoans)
            {
                Console.WriteLine($"Lånebelopp: {loan.Amount} kr, Ränta: {loan.InterestRate}%, Längd på lån: {loan.LengthOfLoan} månader");
            }
        }
        public static void CreateAccount() //Skapa konto för en användare
        {
            Console.WriteLine("Ange kontotyp (1. Sparkonto, 2. Lönekonto):");
            string accountType = Console.ReadLine();
            Console.WriteLine("Ange startbelopp:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal initialDeposit))
            {
                Console.WriteLine("Felaktig inmatning, försök igen!");
                return;
            }
            Account newAccount;
            switch (accountType)
            {
                case "1":
                    newAccount = new SavingsAccount(GenerateAccountNumber(), this.User, initialDeposit, Currency);
                    break;
                case "2":
                    newAccount = new SallaryAccount(GenerateAccountNumber(), this.User, initialDeposit, Currency);
                    break;
                default:
                    Console.WriteLine("Felaktig kontotyp, försök igen!");
                    return;
            }
            AddAccount(newAccount);
            Console.WriteLine($"Konto skapat! Kontonummer: {newAccount.AccountNumber}, Saldo: {newAccount.Balance} {newAccount.Currency}");
        }
        public static void ViewAccount() //Visa alla konton för en användare
        {

            if (AllAccounts.Count == 0)
            {
                Console.WriteLine("Du har inga konton för tillfället.");
                return;
            }
            Console.WriteLine("Dina konton:");
            foreach (var account in AllAccounts)
            {
                Console.WriteLine($"Kontonummer: {account.AccountNumber}, Saldo: {account.Balance} {account.Currency}");
            }
        }
        public static string GenerateAccountNumber() //Förslag på metod för att generera kontonummer
        {
            Random rand = new Random();
            string accountNumber = "";
            for (int i = 0; i < 10; i++)
            {
                accountNumber += rand.Next(0, 10).ToString();
            }
            return accountNumber;
        }

        public static void CreateAccounttest()
        {
            Console.WriteLine("Vilken typ ac konto önskar du att öppna?");
            Console.WriteLine("1. Lönekonto\n2. Sparkonto");
            InputValidation.TrimmedString(Console.ReadLine());
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
