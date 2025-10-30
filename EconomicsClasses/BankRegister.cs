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
        public static void AddLoan(Customer loggedInUser, decimal amount, decimal Interestrate, decimal lenghtOfLoan)
        {
            var loan = new Loan(loggedInUser, amount, Interestrate, lenghtOfLoan);
            AllLoans.Add(loan);
        }

        public static void AddAccount(Account a)
        {
            AllAccounts.Add(a);
        }

        public static void CalculateLoanAmount() //Metod för att räkna ut lånebelopp
        {
            List<Account> customerAccounts = AllAccounts.Where(a => a.loggedInUser is Customer).ToList();
            foreach (var account in customerAccounts) {
                //Exempel på enkel uträkning baserat på kontosaldo
                decimal maxLoanAmount = account.Balance * 5; //Kunden kan låna upp till 5 gånger sitt kontosaldo
                Console.WriteLine($"Kund {account.loggedInUser.FullName} kan låna upp till {maxLoanAmount} kr baserat på sitt konto med saldo {account.Balance} kr.");
            }
        public static void ApplyForLoan(Customer loggedInUser) //Ansök om lån för en användare
        {
            
            //Behöver en metod för att räkna ut hur mycket kunden får låna
            Console.WriteLine("Lånansökan");
            
                Console.WriteLine("Hur mycket önskar du att låna?");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    Console.WriteLine("Felatkig inmatning, försök igen!");
                    return;
                }
                
                    Console.WriteLine("Under hur lånt tid önskar du att betala tillbaka lånet? (Ange antal månader)");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal lengthOfLoan))
                    {
                        Console.WriteLine("Felaktig inmatning, försök igen!");
                        return;
                    }
                    
                
                decimal interest = amount * InterestRate / 100;
                decimal total = amount + interest;
                decimal monthlyPayment = total / lengthOfLoan;

                Console.WriteLine($"Du har ansökt om ett lån på {amount} kr med en ränta på {InterestRate}%. Totalt att återbetala är {total} kr.");
                AddLoan(loggedInUser, amount, InterestRate, lengthOfLoan);        
            
            
            //Lägg till lånet i listan över lån

        }
        public static void ViewLoans(Customer loggedInUser) //Visa alla lån för en användare
        {
            
            if (AllLoans.Count == 0)
            {
                Console.WriteLine("Du har inga lån för tillfället.");
                return;
            }
            Console.WriteLine("Dina lån:");
            foreach (var loan in AllLoans)
            {
                Console.WriteLine($"Lånebelopp: {loan.Amount} kr, Ränta: {loan.InterestRate}%, Längd på lån: {loan.LengthOfLoan} månader");
            }
        }
        public static void CreateAccount(Customer loggedInUser) //Skapa konto för en användare
        {
            Console.WriteLine("Anökan för Konto");
            Console.WriteLine("Ange kontotyp (1. Sparkonto, 2. Lönekonto):");
            string accountType = Console.ReadLine();
            Console.WriteLine("Ange startbelopp:");//är det något vi ska ha?
            if (!decimal.TryParse(Console.ReadLine(), out decimal initialDeposit))
            {
                Console.WriteLine("Felaktig inmatning, försök igen!");
                return;
            }
            Account newAccount;
            //switch (accountType)
            //{
            //    case "1":
            //        newAccount = new SavingsAccount(GenerateAccountNumber(), loggedInUser, initialDeposit, Currency); //skall anropa currency med rätt valuta, väntar på kristin
            //        break;
            //    case "2":
            //        newAccount = new SalaryAccount(GenerateAccountNumber(), loggedInUser, initialDeposit, Currency); //skall anropa currency med rätt valuta, väntar på kristin
            //        break;
            //    default:
            //        Console.WriteLine("Felaktig kontotyp, försök igen!");
            //        return;
            //}
            
           // Console.WriteLine($"Konto skapat! Kontonummer: {newAccount.AccountNumber}, Saldo: {newAccount.Balance} {newAccount.Currency}");
           // AddAccount(newAccount);
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

        
    }
}
