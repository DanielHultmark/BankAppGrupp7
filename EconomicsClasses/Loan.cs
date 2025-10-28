using BankAppGrupp7.UsersClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.EconomicsClasses
{
    internal class Loan
    {
        public Customer User { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }  
        public decimal LengthOfLoan { get; set; }

        public Loan(Customer user, decimal amount, decimal interestRate, decimal lengthOfLoan)
        {
            User = user;
            Amount = amount;
            InterestRate = interestRate;
            LengthOfLoan = lengthOfLoan;

            interestRate = 0.0254M; // Standard ränta på 5%

            List<Loan> listOfLoans = new List<Loan>();            
        }

        public void ApplyForLoan()
        {
            Console.WriteLine("Hur mycket önskar du att låna?");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Felaktig inmatning, försök igen!");
                return;
            }

            Console.WriteLine("Under hur lånt tid önskar du att betala tillbaka lånet?");
            if (!decimal.TryParse(Console.ReadLine(), out decimal lengthOfLoan))
            {
                Console.WriteLine("Felatkig inmatning, försök igen!");
                return;
            }
           
            decimal intrest = amount * InterestRate / 100;
            decimal total = amount + intrest;
            decimal monthlyPayment = total / lengthOfLoan;

            Console.WriteLine($"Du har ansökt om ett lån på {amount} kr med en ränta på {InterestRate}%. Totalt att återbetala är {total} kr.");
            Loan newLoan = new Loan(this.User, amount, InterestRate, lengthOfLoan);
            //Lägg till lånet i listan över lån

        }
        public void ViewLoans()
        {
            
        }
    }
}
