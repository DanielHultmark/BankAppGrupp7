using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.UsersClasses
{
    internal class Customer : User
    {
        public List<Account> Accounts { get; set; } = new List<Account>();
       

        public List<Loan> Loans { get; set; } = new List<Loan>();

    }
}
