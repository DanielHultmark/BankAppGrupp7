using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.UsersClasses
{
    internal class UserRegister
    {
        private List<User> Users { get; set; } = new List<User>()
        {
           new Admin
           {   UserName = "admin",
               Password = "admin",
               FullName = "Sara Struktur"
           },
           new Customer
           {
               UserName = "test",
               Password = "test",
               FullName = "Testa Testsson",
           }
        };

        public void AddCustomerInRegister(string userName, string password, string fullName)
        {
            //Ta emot parametrar från Create customer i Admin

            Users.Add(new Customer { UserName = userName, Password = password, FullName = fullName });
        }

        public void DelteteCustomerInRegister()
        {
            //Ta emot parametrar från Remoce customer i Admin
        }
    }
}
