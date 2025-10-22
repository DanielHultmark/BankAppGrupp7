using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankAppGrupp7.UsersClasses
{
    internal class Admin : User
    {
        public bool isAdmin { get; set; } = true;

        public UserRegister Customers { get; set; }

        public Currency Currency { get; set; }

        public void CreateCustomer()
        {
            // skicka till CustomerRegister
        }

        public void DeleteCustomer()
        {
            //skicka till CustomerRegister
        }   

        public void CheckIfUnique()
        {
            //Help to check if username/password is unique, compare with CustomerRegister
        }

        public void SetCurrency()
        {
            //Interface till admin, skickar/sparar data till currency

        }
        
    }
}
