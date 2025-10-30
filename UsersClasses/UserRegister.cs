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
        public Dictionary<string, User> UserList { get; private set; } = new Dictionary<string, User>()
        {
           ["admin"] = new Admin
           {
               Username = "admin",
               Password = "Admin123",
               FullName = "Sara Struktur"
           },
            ["test"] = new Customer("test", "Test123", "Testa Testsson")
           
        };

        public void AddCustomerInRegister(string username, string password, string fullName)
        {
            //Should key and username be the same?
            UserList.Add(username, new Customer (username, password, fullName));
        }

        public void DeleteCustomerInRegister(string key)
        {
            //Takes the perameters from Admin's DeleteCustomer method
            //Removing from the specified userinput from the list 
            UserList.Remove(key);
        }
    }
}
