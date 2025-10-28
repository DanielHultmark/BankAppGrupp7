using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BankAppGrupp7.EconomicsClasses;
using BankAppGrupp7.MenuClasses;

namespace BankAppGrupp7.UsersClasses
{
    internal class Admin : User
    {
        //Constructor; set IsAdmin to true
        public Admin()
        {
            IsAdmin = true;
        }

        //Method for creating customer
        public void CreateCustomer(UserRegister users)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Lägg till ny kund");

                Console.Write("Användarnamn: ");
                string username = InputValidation.TrimmedString();
                //Checks if the username exist and then skips if it does by resetting the loop
                if (DoesUsernameExist(users, username))
                {
                    Console.WriteLine($"{username} already exists");
                    continue;
                }

                Console.Write("Lösenord: ");
                string password = InputValidation.TrimmedString();
                if(!IsPasswordValid(users, password))
                {
                    continue;
                }

                Console.Write("För- och efternamn: ");
                string fullName = InputValidation.TrimmedString();

                users.AddCustomerInRegister(username, password, fullName);
                isRunning = false;
            }
        }

        public void DeleteCustomer(UserRegister users, string username)
        {
            Console.Clear();
            Console.WriteLine("Ta bort kund");
            username = InputValidation.TrimmedString();
            if (DoesUsernameExist(users, username))
            {
                users.DeleteCustomerInRegister(username);
            }

        }

        public bool DoesUsernameExist(UserRegister users, string userName)
        {
            //Help to check if username/password is unique when adding a customer, compare with already excisting in CustomerRegister
            //Checks if the dictionary contains the specified key Username
            if (users.UserList.ContainsKey(userName)) 
            {
                return true;
            }
            return false;
        }

        public bool IsPasswordValid(UserRegister users, string password)
        {
            const int minLength = 5;
            if(minLength > password.Length)
            {
                Console.WriteLine($"Minimum length for password is: {minLength}\nYour password contains only {password.Length}");
                return false;
            }
            return true;
            
        }
    }
}
