using BankAppGrupp7.AccountClasses;
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
        
        public decimal CalculateLoanAmount(Customer loggedInUser) //Metod för att räkna ut lånebelopp
        {
            List<Account> customerAccounts = bankRegister.AllAccounts.Where(a => a.Owner == loggedInUser).ToList();

            decimal maxLoanAmount = 0;

            foreach (var account in customerAccounts)
            {
                //Exempel på enkel uträkning baserat på kontosaldo
                maxLoanAmount += account.Balance * 5; //Kunden kan låna upp till 5 gånger sitt kontosaldo

            }
            Console.WriteLine($"Kund {loggedInUser.FullName} kan låna upp till {maxLoanAmount}");

            return maxLoanAmount;
        }
        public void ApplyForLoan(Customer loggedInUser) //Ansök om lån för en användare
        {
            decimal maxLoanAmount = CalculateLoanAmount(loggedInUser);

            Console.WriteLine("Lånansökan");

            Console.WriteLine("Hur mycket önskar du att låna?");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
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
            if (!int.TryParse(Console.ReadLine(), out int lengthOfLoan))
            {
                Console.WriteLine("Felaktig inmatning, försök igen!");
                return;
            }


            decimal monthlyInterestRate = bankRegister.InterestRate / 100 / 12; // Ränta per månad
            decimal totalInterest = amount * monthlyInterestRate * lengthOfLoan;
            decimal total = amount + totalInterest;
            decimal monthlyPayment = total / lengthOfLoan;

            Console.WriteLine($"Totalt att återbetala under {lengthOfLoan} månader: {total} kr.");
            Console.WriteLine($"Månadskostnad: {monthlyPayment:F2} kr.");
            bankRegister.AddLoan(loggedInUser, amount, bankRegister.InterestRate, lengthOfLoan);


            //Lägg till lånet i listan över lån

        }
        public void ViewLoans(Customer loggedInUser) //Visa alla lån för en användare
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
        public void CreateAccount(Customer loggedInUser) //Skapa konto för en användare
        {
            Console.WriteLine("Anökan för Konto");
            Console.WriteLine("Ange kontotyp (1. Sparkonto, 2. Lönekonto):");
            string accountType = Console.ReadLine();
            Console.WriteLine("Vilken valuta vill du ha? GBP, EUR, SEK");
            string currencyType = Console.ReadLine();
            Console.WriteLine("Ange startbelopp:");//är det något vi ska ha?
            if (!decimal.TryParse(Console.ReadLine(), out decimal initialDeposit))
            {
                Console.WriteLine("Felaktig inmatning, försök igen!");
                return;
            }
            Account newAccount;
            switch (accountType)
            {
                case "1":
                    newAccount = new SavingsAccount(GenerateAccountNumber(), loggedInUser, initialDeposit, currencyType); //skall anropa currency med rätt valuta, väntar på kristin
                    break;
                case "2":
                    newAccount = new SalaryAccount(GenerateAccountNumber(), loggedInUser, initialDeposit, currencyType); //skall anropa currency med rätt valuta, väntar på kristin

                    break;
                default:
                    Console.WriteLine("Felaktig kontotyp, försök igen!");
                    return;
            }

            Console.WriteLine($"Konto skapat! Kontonummer: {newAccount.AccountNumber}, Saldo: {newAccount.Balance} {newAccount.Currency}");
            bankRegister.AddAccount(newAccount);
        }
        public void ViewAccount(Customer loggedinUser) //Visa alla konton för en användare
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
        }
        public string GenerateAccountNumber() //Förslag på metod för att generera kontonummer
        {
            Random rand = new Random();
            string accountNumber = "";
            do
            {
                accountNumber = string.Concat(Enumerable.Range(0, 10).Select(_ => rand.Next(0, 10).ToString()));
            }
            while (bankRegister.AllAccounts.Any(a => a.AccountNumber == accountNumber)) ;
            accountNumber = bankRegister.AllAccounts.Any(a => a.AccountNumber == accountNumber) ? GenerateAccountNumber() : accountNumber;
            return accountNumber;
        }
        public void ViewTransactions(Customer loggedInUser) //Visa alla transaktioner för en användare
        {
            var customerAccounts = bankRegister.AllAccounts.Where(a => a.Owner == loggedInUser).ToList();
            var customerTransactions = bankRegister.AllTransactions.Where(t => customerAccounts.Contains(t.FromAccount) || customerAccounts.Contains(t.ToAccount)).ToList();
            if (customerTransactions.Count == 0)
            {
                Console.WriteLine("Du har inga transaktioner för tillfället.");
                return;
            }
        }
    }
}

    
