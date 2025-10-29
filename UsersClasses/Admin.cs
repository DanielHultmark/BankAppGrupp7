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
            User user = new User();
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Lägg till ny kund");

                Console.Write("Användarnamn: ");
                string username = InputValidation.TrimmedString();
                //Checks if the username exist and then skips if it does by resetting the loop
                if (DoesUsernameExist(users, user))
                {
                    Console.WriteLine($"{username} finns redan");
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

        public void ViewCustomer(UserRegister users)
        {
            User currentUser = new();
            //Doesn't show the password for user
            foreach (KeyValuePair<string, User> userlist in users.UserList)
            {
                currentUser = userlist.Value;
                Console.WriteLine($"Roll: {userlist.Key}, Användarnamn: {currentUser.Username}, Namn: {currentUser.FullName}\n");
            }

        }
        public void DeleteCustomer(UserRegister users)
        {
            bool isRunning = true;
            User user = new();
            string username;
            //Vad händer om man kommer hit av misstag, tar vi bort while-loopen eller lägger vi till en till else-if sats för att gå tillbaka
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Välj ett användarnamn som ska tas bort");

                username = InputValidation.TrimmedString();
                username = user.Username;
                if (DoesUsernameExist(users, user))
                {
                    Thread.Sleep(1000);
                    users.DeleteCustomerInRegister(user.Username);
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine($"{username} finns inte. Försök igen!");
                    Thread.Sleep(1000);
                }
            }
        }

        public bool DoesUsernameExist(UserRegister users, User username)
        {
            //Help to check if username/password is unique when adding a customer, compare with already excisting in CustomerRegister
            //Checks if the dictionary contains the specified value Username

            if (users.UserList.ContainsValue(username))
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
                Console.WriteLine($"Minsta längden för ett lösenord är: {minLength}\nDitt lösenord har bara {password.Length} tecken");
                return false;
            }
            return true;
            
        }
    }
}
