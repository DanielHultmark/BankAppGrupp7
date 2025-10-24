using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.UsersClasses
{
    internal class UserRegister
    {
         // Default users created to test the app easy
         //We only have one administrator and we dont want to be able to create any more when running the program
        public List<User> UserList { get; private set; } = new List<User>()
        {
           new Admin
           {
               LoginDetails = 
               {
                   ["username"] = "admin",

                   ["password"] = "Admin123",
               },
              
                FullName = "Sara Struktur"
           },        

            new Customer("test", "Test123", "Testa Testsson")
           
        };

        public void AddCustomerInRegister(string username, string password, string fullName)
        {
            UserList.Add(new Customer (username, password, fullName));
        }

        public void DelteteCustomerInRegister()
        {
            //Tar emot parametrar från DeleteCustomer i Admin class
            //Faktiska raderingen i listan sker här
        }
    }
}
