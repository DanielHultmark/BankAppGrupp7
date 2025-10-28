using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.EconomicsClasses
{
    internal class Loans
    {
        public List<Users> User { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }  
        public decimal LengthOfLoan { get; set; }

        public Loans(List<Users> user, decimal amount, decimal interestRate, decimal lengthOfLoan)
        {
            User = user;
            Amount = amount;
            InterestRate = interestRate;
            LengthOfLoan = lengthOfLoan;

            interestRate = 0.0254M; // Standard ränta på 5%

            List<Loans> listOfLoans = new List<Loans>();            
        }

        public void ApplyForLoan()
        {
            Console.WriteLine("Hur mycket önskar du att låna?");
            
            
            Console.WriteLine("Under hur lånt tid önskar du att betala tillbaka lånet?");
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
            decimal total = amount * InterestRate / 100;
            Console.WriteLine($"Du har ansökt om ett lån på {amount} kr med en ränta på {InterestRate}%. Totalt att återbetala är {total} kr.");
            Loans newLoan = new Loans(this.User, amount, InterestRate, lengthOfLoan);
            //Lägg till lånet i listan över lån

        }
        public void ViewLoans()
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
    }
}
