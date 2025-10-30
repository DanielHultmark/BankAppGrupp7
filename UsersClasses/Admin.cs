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
                    InputValidation.ShowFeedbackMessage($"{username} finns redan", ConsoleColor.Red, 2000);
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
                InputValidation.ShowFeedbackMessage("Kund tillagd!", ConsoleColor.Green, 2000);
                isRunning = false;
            }
        }

        public void ViewCustomer(UserRegister users)
        {
            
            //Doesn't show the password when written out for security purposes
            //KeyValuePair is needed for foreach with dictionaries
            foreach (KeyValuePair<string, User> userlist in users.UserList)
            {
                
                Console.WriteLine($"Användarnamn: {userlist.Value.Username}, För- och efternamn: {userlist.Value.FullName}\n");
            }

        }
        public void DeleteCustomer(UserRegister users)
        {
            bool isRunning = true;
            string username;
            //Vad händer om man kommer hit av misstag, tar vi bort while-loopen eller lägger vi till en till else-if sats för att gå tillbaka
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Ta bort kund");
                Console.Write("Skriv användarnamn: ");
                
                username = InputValidation.TrimmedString();
                if (DoesKeyExist(users, username))
                {
                    //Checks if the user is admin and then either stops if it is admin
                    User user = users.UserList[username];
                    if (user.IsAdmin)
                    {
                        InputValidation.ShowFeedbackMessage("Du kan inte ta bort admin!", ConsoleColor.Red, 2000);
                        isRunning=false;
                    }
                    else
                    {
                        Thread.Sleep(1000);
                        users.DeleteCustomerInRegister(username);
                        isRunning=false;
                    }
                    //This foreach-loop prevents admin deletion
                    //foreach (KeyValuePair<string, User> userlist in users.UserList)
                    //{
                    //    User currentUser = userlist.Value;
                    //    string key = userlist.Key;
                    //    if (currentUser.Username == username)
                    //    {
                    //        //Checks if the user is admin, admin class has it set to true so if the user trying to get removed is admin you come here
                    //        if (currentUser.IsAdmin)
                    //        {
                    //            Console.WriteLine("Du får inte ta bort en admin!");
                    //            Thread.Sleep(1000);
                    //            isRunning = false;
                    //        }
                    //        else
                    //        {
                    //            //If it's a customer then it gets removed
                    //            Thread.Sleep(1000);
                    //            users.DeleteCustomerInRegister(key);
                    //            isRunning = false;
                    //        }
                    //    }
                    //}
                }
                else
                {
                    InputValidation.ShowFeedbackMessage($"{username} finns inte. Försök igen!", ConsoleColor.Red, 2000);
                }
            }
        }

        public bool DoesUsernameExist(UserRegister users, string username)
        {
            //Help to check if username/password is unique when adding a customer, compare with already excisting in CustomerRegister
            //Checks if the dictionary contains the specified value Username
            //Goes through the dictionary to see if the userinput matches the username in UserList
            foreach (KeyValuePair<string, User> userlist in users.UserList)
            {
                User currentUser = userlist.Value;
                if (currentUser.Username == username)
                {
                    return true;
                }
            }
            return false;
        }

        public bool DoesKeyExist (UserRegister users, string key)
        {
            if (users.UserList.ContainsKey(key))
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
                InputValidation.ShowFeedbackMessage($"Minsta längden för ett lösenord är: {minLength}\nDitt lösenord har bara {password.Length} tecken", ConsoleColor.Red, 2000);
                return false;
            }
            return true;
            
        }

        public void ViewCustomers(UserRegister users)
        {
            //Print all customers in rows. What info to print; username and name? Account/Loan also?
        }
    }
}
