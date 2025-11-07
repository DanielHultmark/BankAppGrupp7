using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BankAppGrupp7.AccountClasses;
using BankAppGrupp7.MenuClasses;
using BankAppGrupp7.MenuClasses;
using BankAppGrupp7.UsersClasses;
using static System.Net.Mime.MediaTypeNames;

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

            Console.WriteLine($"Du kan låna upp till {maxLoanAmount:F2} SEK\n");

            return maxLoanAmount;
        }

        public void ApplyForLoan(Customer loggedInUser) //Customer applies for a loan
        {
            ConsoleUI.ShowHeader("Låneansökan");
            decimal maxLoanAmount = CalculateLoanAmount(loggedInUser);

            Console.Write("Hur mycket önskar du att låna? ");
            
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

            Console.Write("Under hur lång tid önskar du att betala tillbaka lånet? (Ange antal månader) ");
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
            ConsoleUI.ShowHeader("Dina lån");
            foreach (var loan in customerLoans)
            {
                Console.WriteLine($"Lånebelopp: {loan.Amount} kr, Ränta: {loan.InterestRate}%, Längd på lån: {loan.LengthOfLoan} månader");
            }
        }

        public void CreateAccount(Customer loggedInUser) //Create a new account for a user
        {

            ConsoleUI.ShowHeader("Skapa nytt konto");
            Console.Write("Ange kontotyp (1. Sparkonto, 2. Lönekonto): ");
            string accountType = InputValidation.TrimmedString();

            Console.Write("Vilken valuta vill du ha (GBP, EUR, SEK): ");
            string currencyInput = InputValidation.TrimmedStringToUpper();
            if (!Enum.TryParse(currencyInput, out CurrencyCode currencyType))
            {
                Console.WriteLine("Felaktig valuta, försök igen!");
                return;
            }

            Console.Write("Ange startbelopp: ");
            if (!decimal.TryParse(InputValidation.TrimmedString(), out decimal initialDeposit))
            {
                Console.WriteLine("Felaktig inmatning, försök igen!");
                return;
            }
            
            switch (accountType)
            {
                case "1":                    
                    BankRegister.AddAccount(new SavingsAccount("Sparkonto", GenerateAccountNumber(), loggedInUser, initialDeposit, currencyType));
                    break;
                case "2":
                    BankRegister.AddAccount(new SalaryAccount("Lönekonto", GenerateAccountNumber(), loggedInUser, initialDeposit, currencyType));
                    break;
                default:
                    Console.WriteLine("Felaktig kontotyp, försök igen!");
                    return;
            }                        
        }

        public void ViewAccount(Customer loggedinUser) //Show all accounts for a user
        {
            var customerAccounts = BankRegister.AllAccounts.Where(a => a.Owner.Username == loggedinUser.Username).ToList();
            if (BankRegister.AllAccounts.Count == 0)
            {
                ConsoleUI.ShowFeedbackMessage("Du har inga konton för tillfället.", ConsoleColor.White);
                ConsoleUI.ReturnToMenu();
                return;
            }

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                ConsoleUI.ShowHeader("Dina konton");

                PrintAccountDetails();                        
            
                Console.WriteLine("\n1. Gör en överföring\n" +
                    "2. Se alla överföringar\n" +
                    "3. Gå tillbaka");

                int choice = InputValidation.ReadIntInput("\nVälj:");

                switch (choice)
                {
                    case 1:
                        MakeTransaction();
                        ConsoleUI.ReturnToMenu();
                        break;

                    case 2:
                        ViewTransactions(loggedinUser);
                        ConsoleUI.ReturnToMenu();
                        break;

                    case 3:
                        isRunning = false;
                        break;

                    default:
                        ConsoleUI.ShowFeedbackMessage("Felaktigt val, försök igen.", ConsoleColor.Red, 1500);                        
                        break;
                }
            }
        }
        
        public void ViewTransactions(Customer loggedInUser) //Show all transactions for a user
        {
            Console.Clear();

            var customerAccounts = BankRegister.AllAccounts.Where(a => a.Owner == loggedInUser).ToList();
            var customerTransactions = BankRegister.AllTransactions.Where(t => customerAccounts.Contains(t.FromAccount) || customerAccounts.Contains(t.ToAccount)).ToList();

            if (customerTransactions.Count == 0)
            {
                ConsoleUI.ShowFeedbackMessage("Du har inga överföringar för tillfället.", ConsoleColor.White);                
                return;
            }

            else
            {
                ConsoleUI.ShowHeader("Dina överföringar");
                foreach (var transaction in customerTransactions)
                {
                    Console.WriteLine($"Från konto: {transaction.FromAccount.AccountNumber,-15} Till konto: {transaction.ToAccount.AccountNumber, -15} Belopp: {transaction.Amount:F2}");
                }                
            }
        }

        public void MakeTransaction() //Make a transaction between two accounts
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                ConsoleUI.ShowHeader("Dina konton");

                PrintAccountDetails();
                Console.WriteLine();

                ConsoleUI.ShowHeader("Gör överföring");

                Console.Write("Vilket konto vill du föra över pengar ifrån? ");
                string fromAccountNumber = InputValidation.TrimmedString();
                Account fromAccount = BankRegister.GetAccountByAccountNumber(fromAccountNumber);

                if (fromAccount == null)
                {
                    ConsoleUI.ShowFeedbackMessage("Fel: Kontot hittades inte.", ConsoleColor.Red, 1500);
                    continue;
                }

                Console.Write("\nVilket konto vill du föra över pengar till? ");
                string toAccountNumber = InputValidation.TrimmedString();
                Account toAccount = BankRegister.GetAccountByAccountNumber(toAccountNumber);

                if (toAccount == null)
                {
                    ConsoleUI.ShowFeedbackMessage("Fel: Kontot hittades inte.", ConsoleColor.Red, 1500);
                    continue;
                }

                if (fromAccount.AccountNumber == toAccount.AccountNumber)
                {
                    ConsoleUI.ShowFeedbackMessage("Fel: Du kan inte överföra till samma konto.", ConsoleColor.Red, 1500);

                    continue;
                }

                Console.Write("\nHur mycket pengar vill du föra över? ");
                decimal amount = InputValidation.Decimal();

                if (amount > fromAccount.Balance)
                {
                    ConsoleUI.ShowFeedbackMessage("Fel: Kontot har inte täckning.", ConsoleColor.Red, 1500);
                    continue;
                }

                ConsoleUI.ShowFeedbackMessage("Transaktionen mottagen, och utförs var 15e minut!", ConsoleColor.Green, 2000);

                TransactionManager.AddPendingTransaction(amount, fromAccount, toAccount);

                isRunning = false;
            }
        }

        public void PrintAccountDetails()
        {
            foreach (var account in BankRegister.AllAccounts)
            {
                Console.WriteLine($"Kontotyp: {account.AccountType,-15} Kontonummer: {account.AccountNumber,-15} Saldo: {account.Balance:F2} {account.Currency,-15}");
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
    }
}

    
