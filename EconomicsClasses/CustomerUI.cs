using BankAppGrupp7.AccountClasses;
using BankAppGrupp7.MenuClasses;
using BankAppGrupp7.UsersClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAppGrupp7.MenuClasses;

namespace BankAppGrupp7.EconomicsClasses
{
    public class CustomerUI
    {       
        
        
        public decimal CalculateLoanAmount(Customer loggedInUser) //Method to calculate maximum loan amount for a user
        {
            List<Account> customerAccounts = BankRegister.AllAccounts.Where(a => a.Owner == loggedInUser).ToList();
            decimal maxLoanAmount = 0;

            foreach (var account in customerAccounts)
            {
                decimal convertedAmount = CurrencyConversion.ConvertCurrency(account.Balance, account.Currency, CurrencyCode.SEK);
                maxLoanAmount += convertedAmount * 5; 

            }
            Console.WriteLine($"Du kan låna upp till {maxLoanAmount:F2} SEK");

            return maxLoanAmount;
        }
        public void ApplyForLoan(Customer loggedInUser) //Customer applies for a loan
        {
            ConsoleUI.ShowHeader("LÅNEANSÖKAN");
            decimal maxLoanAmount = CalculateLoanAmount(loggedInUser);
            Console.WriteLine("Hur mycket önskar du att låna?");
            
            if (!decimal.TryParse(InputValidation.TrimmedString(), out decimal amount))
            {
                Console.WriteLine("Felaktig inmatning, försök igen!");
                return;
            }
            if (amount > maxLoanAmount)
            {
                Console.WriteLine($"Du kan inte låna mer än {maxLoanAmount:F2} kr. Försök igen!");
                return;
            }

            Console.WriteLine("Under hur lång tid önskar du att betala tillbaka lånet? (Ange antal månader)");
            if (!int.TryParse(InputValidation.TrimmedString(), out int lengthOfLoan))
            {
                Console.WriteLine("Felaktig inmatning, försök igen!");
                return;
            }


            decimal monthlyInterestRate = BankRegister.InterestRate / 100 / 12; //Interest rate per month
            decimal totalInterest = amount * monthlyInterestRate * lengthOfLoan;
            decimal total = amount + totalInterest;
            decimal monthlyPayment = total / lengthOfLoan;

            Console.WriteLine($"Totalt att återbetala under {lengthOfLoan} månader: {total:F2} kr.");
            Console.WriteLine($"Månadskostnad: {monthlyPayment:F2} kr.");
            BankRegister.AddLoan(loggedInUser, amount, BankRegister.InterestRate, lengthOfLoan);

            
        }
        public void ViewLoans(Customer loggedInUser) //Show all loans for a user
        {
            var customerLoans = BankRegister.AllLoans.Where(l => l.Customer == loggedInUser).ToList();

            if (customerLoans.Count == 0)
            {
                Console.WriteLine("Du har inga lån för tillfället.");
                return;
            }
            ConsoleUI.ShowHeader("DINA LÅN");
            foreach (var loan in customerLoans)
            {
                Console.WriteLine($"Lånebelopp: {loan.Amount} kr, Ränta: {loan.InterestRate}%, Längd på lån: {loan.LengthOfLoan} månader");
            }
        }
        public void CreateAccount(Customer loggedInUser) //Create a new account for a user
        {

            ConsoleUI.ShowHeader("SKAPA NYTT KONTO");
            Console.WriteLine("Ange kontotyp (1. Sparkonto, 2. Lönekonto):");
            string accountType = InputValidation.TrimmedString();

            Console.WriteLine("Vilken valuta vill du ha? GBP, EUR, SEK");
            string currencyInput = InputValidation.TrimmedStringToUpper();
            if (!Enum.TryParse(currencyInput, out CurrencyCode currencyType))
            {
                Console.WriteLine("Felaktig valuta, försök igen!");
                return;
            }

            Console.WriteLine("Ange startbelopp:");
            if (!decimal.TryParse(InputValidation.TrimmedString(), out decimal initialDeposit))
            {
                Console.WriteLine("Felaktig inmatning, försök igen!");
                return;
            }
            Account newAccount;
            switch (accountType)
            {
                case "1":                    
                    newAccount = new SavingsAccount("Sparkonto", GenerateAccountNumber(), loggedInUser, initialDeposit, currencyType);
                    break;
                case "2":
                    newAccount = new SalaryAccount("Lönekonto", GenerateAccountNumber(), loggedInUser, initialDeposit, currencyType);
                    break;
                default:
                    Console.WriteLine("Felaktig kontotyp, försök igen!");
                    return;
            }
            if (accountType == "1")
            {
                Console.WriteLine($"Konto skapat! Kontonummer: {newAccount.AccountNumber}, Saldo: {newAccount.Balance:F2} {newAccount.Currency} med räntan: 1,05%");
            }
            else
            {
                Console.WriteLine($"Konto skapat! Kontonummer: {newAccount.AccountNumber}, Saldo: {newAccount.Balance:F2} {newAccount.Currency}");
            }
            BankRegister.AddAccount(newAccount);
        }
        public void ViewAccount(Customer loggedinUser) //Show all accounts for a user
        {
            var customerAccounts = BankRegister.AllAccounts.Where(a => a.Owner == loggedinUser).ToList();
            if (BankRegister.AllAccounts.Count == 0)
            {
                Console.WriteLine("Du har inga konton för tillfället.");
                return;
            }
            ConsoleUI.ShowHeader("DINA KONTON");

            
            foreach (var account in BankRegister.AllAccounts)
            {
                Console.WriteLine($"Kontotyp: {account.AccountType, -15}, Kontonummer: {account.AccountNumber, -15}, Saldo: {account.Balance:F2} {account.Currency,-15}");
            }
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n1. Gör en överföring\n2. Se alla överföringar\n3. Gå tillbaka");
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
            while (BankRegister.AllAccounts.Any(a => a.AccountNumber == accountNumber));
            {
                accountNumber = BankRegister.AllAccounts.Any(a => a.AccountNumber == accountNumber) ? GenerateAccountNumber() : accountNumber;
                return accountNumber;
            }
        }
        public void ViewTransactions(Customer loggedInUser) //Show all transactions for a user
        {
            var customerAccounts = BankRegister.AllAccounts.Where(a => a.Owner == loggedInUser).ToList();
            var customerTransactions = BankRegister.AllTransactions.Where(t => customerAccounts.Contains(t.FromAccount) || customerAccounts.Contains(t.ToAccount)).ToList();
            if (customerTransactions.Count == 0)
            {
                Console.WriteLine("Du har inga transaktioner för tillfället.");
                return;
            }
            else
            {
                foreach (var transaction in customerTransactions)
                {
                    Console.WriteLine($"Från konto: {transaction.FromAccount.AccountNumber,-15}, Till konto: {transaction.ToAccount.AccountNumber, -15}, Belopp: {transaction.Amount:F2}");
                }                
            }
        }
        public void MakeTransaction() //Make a transaction between two accounts
        {
            Console.WriteLine("Vilket konto vill du flytta pengar ifrån");
            string fromAccountNumber = InputValidation.TrimmedString();
            Account fromAccount = BankRegister.GetAccountByAccountNumber(fromAccountNumber);
            if (fromAccount == null)
            {
                Console.WriteLine("Fel: Kontot hittades inte.");
                return;
            }
            Console.WriteLine("Vilket konto vill du flytta pengar till");
            string toAccountNumber = InputValidation.TrimmedString();
            Account toAccount = BankRegister.GetAccountByAccountNumber(toAccountNumber);
            if (toAccount == null)
            {
                Console.WriteLine("Fel: Kontot hittades inte.");
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
                Console.WriteLine("Kontot saknar täckning!");
            }
            ConsoleUI.ShowFeedbackMessage("Transaktionen mottagen, och utförs var 15e minut!", ConsoleColor.Green, 2000);
            TransactionManager.AddPendingTransaction(amount, fromAccount, toAccount);
        }
    }
}

    
