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

        public void CreateCustomer(UserRegister users)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Lägg till ny kund");

                Console.Write("Användarnamn: ");
                string username = InputValidation.TrimmedString();
                if (!IsUsernameUnique(users, username))
                {
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
            //Instruktioner för admin att ta bort en customer

            // Vilka argument ska DelteteCustomerInRegister() ta?
            Console.WriteLine("Ta bort kund");
            username = InputValidation.TrimmedString();
            if (!IsUsernameUnique(users, username))
            {

            }

            users.DeleteCustomerInRegister(username);
        }

        public bool IsUsernameUnique(UserRegister users, string userName)
        {
            //Help to check if username/password is unique when adding a customer, compare with already excisting in CustomerRegister
            //Checks if the dictionary contains the specified key Username
            if (users.UserList.ContainsKey(userName)) 
            {
                Console.WriteLine($"{userName} already exists");
                return false;
            }
            return true;
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
