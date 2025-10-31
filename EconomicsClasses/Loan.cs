using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using BankAppGrupp7.UsersClasses;

namespace BankAppGrupp7.EconomicsClasses
{
    public class Loan
    {
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }  
        public decimal LengthOfLoan { get; set; }

        public Loan(Customer customer, decimal amount, decimal interestRate, decimal lengthOfLoan)
        {
            Customer = customer;
            Amount = amount;
            InterestRate = interestRate;
            LengthOfLoan = lengthOfLoan;

            interestRate = 0.0254M; // Standard ränta på 5%

                        
        }

         
        
    }
}
