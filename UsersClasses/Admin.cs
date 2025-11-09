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
    public class Admin : User
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
                ConsoleUI.ShowHeader("Lägg till ny kund");

                Console.Write("Användarnamn: ");
                string username = InputValidation.TrimmedString();
                //Checks if the username exist and then skips if it does by resetting the loop
                if (DoesUsernameExist(users, username))
                {
                    ConsoleUI.ShowFeedbackMessage($"{username} finns redan", ConsoleColor.Red, 1500);
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
                ConsoleUI.ShowFeedbackMessage("Kund tillagd!", ConsoleColor.Green, 1500);
                isRunning = false;
            }
        }
        public void ViewCustomers(UserRegister users)
        {
            Console.Clear();
            ConsoleUI.ShowHeader("Alla kunder");

            //Doesn't show the password when written out for security purposes
            //KeyValuePair is needed for foreach with dictionaries
            foreach (KeyValuePair<string, User> userlist in users.UserList)
            {
                if (!userlist.Value.IsAdmin)
                {
                    Console.WriteLine($"Användarnamn: {userlist.Value.Username, -15} För- och efternamn: {userlist.Value.FullName}\n");
                }                
            }
        }
        public void DeleteCustomer(UserRegister users)
        {
            bool isRunning = true;
            string username;
            //At the moment you can't get back if you go here by mistake. We could remoce the while loop or add a n else-if  to go back.
            while (isRunning)
            {
                Console.Clear();
                ConsoleUI.ShowHeader("Ta bort kund");
                Console.Write("Skriv användarnamn: ");
                
                username = InputValidation.TrimmedString();
                if (DoesKeyExist(users, username))
                {
                    //Checks if the user is admin and then either stops if it is admin or continues if it's user
                    User user = users.UserList[username];
                    if (user.IsAdmin)
                    {
                        ConsoleUI.ShowFeedbackMessage("Du kan inte ta bort admin!", ConsoleColor.Red, 1500);
                        isRunning=false;
                    }
                    else
                    {
                        //Last check to see if the user should be deleted or not
                        Console.WriteLine($"Vill du ta bort {username}? Ja eller Nej");
                        string choice = InputValidation.TrimmedStringToLower();
                        if(choice == "ja")
                        {
                            ConsoleUI.ShowFeedbackMessage($"Tar bort {username}", ConsoleColor.Green, 1500);                            
                            users.DeleteCustomerInRegister(username);
                            isRunning = false;
                        }
                        else if (choice == "nej")
                        {
                            ConsoleUI.ShowFeedbackMessage($"Tar inte bort {username}", ConsoleColor.Green, 1500);
                            isRunning = false;
                        }
                        else
                        {
                            ConsoleUI.ShowFeedbackMessage("Välj mellan Ja och Nej", ConsoleColor.Red, 1500);
                        }                        
                    }                    
                }
                else
                {
                    ConsoleUI.ShowFeedbackMessage($"{username} finns inte. Försök igen!", ConsoleColor.Red, 1500);
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
                ConsoleUI.ShowFeedbackMessage($"Minsta längden för ett lösenord är: {minLength}\nDitt lösenord har bara {password.Length} tecken", ConsoleColor.Red, 1500);
                return false;
            }
            return true;
            
        }

        
    }
}
