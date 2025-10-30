using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using BankAppGrupp7.UsersClasses;

namespace BankAppGrupp7.EconomicsClasses
{
    internal class Loan
    {
        public List<User> User { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }  
        public decimal LengthOfLoan { get; set; }

        public Loan(List<User> user, decimal amount, decimal interestRate, decimal lengthOfLoan)
        {
            User = user;
            Amount = amount;
            InterestRate = interestRate;
            LengthOfLoan = lengthOfLoan;

            

                       
        }

        
        
    }
}
