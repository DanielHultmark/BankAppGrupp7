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
    public class CustomerUI
    {
        
        BankRegister bankRegister = new BankRegister();
        
        public decimal CalculateLoanAmount(Customer loggedInUser) //Method to calculate maximum loan amount for a user
        {
            List<Account> customerAccounts = bankRegister.AllAccounts.Where(a => a.Owner == loggedInUser).ToList();

            decimal maxLoanAmount = 0;

            foreach (var account in customerAccounts)
            {
                
                maxLoanAmount += account.Balance * 5; 

            }
            Console.WriteLine($"Du kan låna upp till {maxLoanAmount}");

            return maxLoanAmount;
        }
        public void ApplyForLoan(Customer loggedInUser) //Customer applies for a loan
        {
            Console.WriteLine("Lånansökan");

            Console.WriteLine("Hur mycket önskar du att låna?");
            decimal maxLoanAmount = CalculateLoanAmount(loggedInUser);
            if (!decimal.TryParse(InputValidation.TrimmedString(), out decimal amount))
            {
                Console.WriteLine("Felatkig inmatning, försök igen!");
                return;
            }
            if (amount > maxLoanAmount)
            {
                Console.WriteLine($"Du kan inte låna mer än {maxLoanAmount} kr. Försök igen!");
                return;
            }

            Console.WriteLine("Under hur lånt tid önskar du att betala tillbaka lånet? (Ange antal månader)");
            if (!int.TryParse(InputValidation.TrimmedString(), out int lengthOfLoan))
            {
                Console.WriteLine("Felaktig inmatning, försök igen!");
                return;
            }


            decimal monthlyInterestRate = bankRegister.InterestRate / 100 / 12; //interest rate per month
            decimal totalInterest = amount * monthlyInterestRate * lengthOfLoan;
            decimal total = amount + totalInterest;
            decimal monthlyPayment = total / lengthOfLoan;

            Console.WriteLine($"Totalt att återbetala under {lengthOfLoan} månader: {total} kr.");
            Console.WriteLine($"Månadskostnad: {monthlyPayment:F2} kr.");
            bankRegister.AddLoan(loggedInUser, amount, bankRegister.InterestRate, lengthOfLoan);

            
        }
        public void ViewLoans(Customer loggedInUser) //show all loans for a user
        {
            var customerLoans = bankRegister.AllLoans.Where(l => l.Customer == loggedInUser).ToList();

            if (customerLoans.Count == 0)
            {
                Console.WriteLine("Du har inga lån för tillfället.");
                return;
            }
            Console.WriteLine("Dina lån:");
            foreach (var loan in customerLoans)
            {
                Console.WriteLine($"Lånebelopp: {loan.Amount} kr, Ränta: {loan.InterestRate}%, Längd på lån: {loan.LengthOfLoan} månader");
            }
        }
        public void CreateAccount(Customer loggedInUser) //Create a new account for a user
        {

            Console.WriteLine("Anökan för Konto");
            Console.WriteLine("Ange kontotyp (1. Sparkonto, 2. Lönekonto):");
            string accountType = InputValidation.TrimmedString();

            Console.WriteLine("Vilken valuta vill du ha? GBP, EUR, SEK");
            string currencyInput = InputValidation.TrimmedStringToUpper();
            if (!Enum.TryParse(currencyInput, out CurrencyCode currencyType))
            {
                Console.WriteLine("Felaktig valuta, försök igen!");
                return;
            }

            Console.WriteLine("Ange startbelopp:");//är det något vi ska ha?
            if (!decimal.TryParse(InputValidation.TrimmedString(), out decimal initialDeposit))
            {
                Console.WriteLine("Felaktig inmatning, försök igen!");
                return;
            }
            Account newAccount;
            switch (accountType)
            {
                case "1":
                    newAccount = new SavingsAccount(GenerateAccountNumber(), loggedInUser, initialDeposit, currencyType);
                    break;
                case "2":
                    newAccount = new SalaryAccount(GenerateAccountNumber(), loggedInUser, initialDeposit, currencyType);

                    break;
                default:
                    Console.WriteLine("Felaktig kontotyp, försök igen!");
                    return;
            }
            if (accountType == "1")
            {
                Console.WriteLine($"Konto skapat! Kontonummer: {newAccount.AccountNumber}, Saldo: {newAccount.Balance} {newAccount.Currency} med räntan: 1,05%");
            }
            else
            {
                Console.WriteLine($"Konto skapat! Kontonummer: {newAccount.AccountNumber}, Saldo: {newAccount.Balance} {newAccount.Currency}");
            }
            bankRegister.AddAccount(newAccount);
        }
        public void ViewAccount(Customer loggedinUser) //Show all accounts for a user
        {
            var customerAccounts = bankRegister.AllAccounts.Where(a => a.Owner == loggedinUser).ToList();
            if (bankRegister.AllAccounts.Count == 0)
            {
                Console.WriteLine("Du har inga konton för tillfället.");
                return;
            }
            Console.WriteLine("Dina konton:");
            foreach (var account in bankRegister.AllAccounts)
            {
                Console.WriteLine($"Kontonummer: {account.AccountNumber}, Saldo: {account.Balance} {account.Currency}");
            }
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("1. Gör en överföring\n2. Se alla överföringar\n3. Gå tillbaka");
                int choice = InputValidation.ReadIntInput("\nVälj:");

                switch (choice)
                {
                    case 1:
                        MakeTransaction();
                        break;
                    case 2:
                        ViewTransactions(loggedinUser);
                        break;
                    case 3:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Felaktigt val, försök igen.");
                        Thread.Sleep(2000);
                        break;

                }
            }
        }
        public string GenerateAccountNumber() //Generate a unique account number
        {
            Random rand = new Random();
            string accountNumber = "";
            do
            {
                accountNumber = string.Concat(Enumerable.Range(0, 10).Select(_ => rand.Next(0, 10).ToString()));
            }
            while (bankRegister.AllAccounts.Any(a => a.AccountNumber == accountNumber));
            {
                accountNumber = bankRegister.AllAccounts.Any(a => a.AccountNumber == accountNumber) ? GenerateAccountNumber() : accountNumber;
                return accountNumber;
            }
        }
        public void ViewTransactions(Customer loggedInUser) //Show all transactions for a user
        {
            var customerAccounts = bankRegister.AllAccounts.Where(a => a.Owner == loggedInUser).ToList();
            var customerTransactions = bankRegister.AllTransactions.Where(t => customerAccounts.Contains(t.FromAccount) || customerAccounts.Contains(t.ToAccount)).ToList();
            if (customerTransactions.Count == 0)
            {
                Console.WriteLine("Du har inga transaktioner för tillfället.");
                return;
            }
        }
        public void MakeTransaction() //Make a transaction between two accounts
        {
            

            Console.WriteLine("Vilket konto vill du flytta pengar ifrån");
            string fromAccountNumber = InputValidation.TrimmedString();
            Account fromAccount = bankRegister.GetAccountByAccountNumber(fromAccountNumber);
            if (fromAccount == null)
            {
                Console.WriteLine("Fel: Mottagarkontot hittades inte.");
                return;
            }

            Console.WriteLine("Vilket konto vill du flytta pengar till");
            string toAccountNumber = InputValidation.TrimmedString();
            Account toAccount = bankRegister.GetAccountByAccountNumber(toAccountNumber);
            if (toAccount == null)
            {
                Console.WriteLine("Fel: Mottagarkontot hittades inte.");
                return;
            }

            if (fromAccount.AccountNumber == toAccount.AccountNumber)
            {
                Console.WriteLine("Fel: Du kan inte överföra till samma konto.");
                return;
            }

            Console.WriteLine("Hur mycket pengar vill du flytta?");
            decimal amount = InputValidation.Decimal();

            if (amount > fromAccount.Balance)
            {
                throw new InvalidOperationException("Fel. Överstiger kontots saldo.");
            }

            CurrencyConversion currencyConversion = new CurrencyConversion();
            decimal convertedAmount = currencyConversion.ConvertCurrency(amount, fromAccount.Currency, toAccount.Currency);

            fromAccount.Balance -= amount;
            toAccount.Balance += convertedAmount;

            InputValidation.ShowFeedbackMessage("Transaktionen lyckades!", ConsoleColor.Green, 2000);
            Transaction transaction = new Transaction(amount, fromAccount, toAccount);

            bankRegister.AddTransaction(transaction);

        }
    }
}

    
