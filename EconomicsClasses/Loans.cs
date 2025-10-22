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
        public double Amount { get; set; }
        public double InterestRate { get; set; }  
        public double LengthOfLoan { get; set; }

        public Loans(List<Users> user, double amount, double interestRate, double lengthOfLoan)
        {
            User = user;
            Amount = amount;
            InterestRate = interestRate;
            LengthOfLoan = lengthOfLoan;

            interestRate = 0.0254; // Standard ränta på 5%

            List<Loans> listOfLoans = new List<Loans>();            
        }

        public void ApplyForLoan()
        {
            Console.WriteLine("Hur mycket önskar du att låna?");
            double amount = Convert.ToDouble(Console.ReadLine());
            double total = amount * InterestRate / 100;
            Console.WriteLine("Under hur lånt tid önskar du att betala tillbaka lånet?");
            int years = int.TryParse(Console.ReadLine());
            Console.WriteLine($"Du har ansökt om ett lån på {amount} kr med en ränta på {InterestRate}%. Totalt att återbetala är {total} kr.");
            Loans newLoan = new Loans(this.User, amount, InterestRate);
            
        }
    }
}
