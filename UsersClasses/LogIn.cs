using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using BankAppGrupp7.MenuClasses;

namespace BankAppGrupp7.UsersClasses
{
    internal class LogIn
    {    
        public int MaxLoginAttempts { get; set; } = 3;

        public UserRegister Users { get; set; } = new UserRegister();

        public Menu menu { get; set; } = new Menu();

        // The log in view refreshes if the user has given invalid input in some way. 
        // As it is now the only way to get out of the log in view is to give valid login details. 
        public void LoginUI() //
        {
            bool stillEnteringLoginDetails = true;

            while (stillEnteringLoginDetails)
            {
                Console.Clear();

                ConsoleUI.ShowHeader("CIBA – där ekonomi möter innovation");
                ConsoleUI.ShowHeader("Fyll i inloggningsuppgifter");

                string username = InputValidation.ReadStringInput("Användarnamn:");

                if (!IsUsernameValid(username))
                {
                    continue;
                }
                
                string password = InputValidation.ReadStringInput("Lösenord:");

                if (!IsPasswordValid(username, password))
                {
                    continue;
                }  
                
                LoggedIn(username);
                stillEnteringLoginDetails = false;
            }    
        }

        public bool IsUsernameValid(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                ConsoleUI.ShowFeedbackMessage("Ogiltig inmatning, försök igen!", ConsoleColor.Red, 2000);
                return false;
            }

            bool usernameExists = Users.UserList.ContainsKey(username);

            if (!usernameExists)
            {
                ConsoleUI.ShowFeedbackMessage("Användarnamn saknas, försök igen!", ConsoleColor.Red, 1000);

                return false;
            }

            bool isLockedOut = IsAccountLocked(username);

            if (isLockedOut)
            {
                return false;
            }

            return true;

        }

        //Should user be sent back to start menu when the account has been locked?
        public bool IsPasswordValid(string username, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                ConsoleUI.ShowFeedbackMessage("Ogiltig inmatning, försök igen!", ConsoleColor.Red, 2000);
                return false;
            }

            var user = Users.UserList[username];
            bool isPasswordCorrect = user.Password.Equals(password);

            if (isPasswordCorrect)
            {
                return true;
            }

            user.IncreaseNumberLoginAttempts();
            int remainingAttempts = MaxLoginAttempts - user.FailedLoginAttempts;

            Console.ForegroundColor = ConsoleColor.Red;

            if (remainingAttempts>0)
            {                        
                Console.Write($"Lösenordet är felaktigt, du har {remainingAttempts} försök kvar!");

                Thread.Sleep(2000);
            }
                    
            else
            {
                Console.Write($"Användarkontot har låsts pga för många inloggningsförsök. Kontakta kundtjänst.");

                Thread.Sleep(4000);
            }

            Console.ResetColor();          
            
            return false;
        }

        //Should user be sent back to start menu when the account is locked?
        public bool IsAccountLocked(string username)
        {
            User user = Users.UserList[username];
            if (user.FailedLoginAttempts < MaxLoginAttempts)
            {
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nDitt användarkonto är låst pga för många inloggningsförsök. Kontakta kundtjänst.");
            Console.ResetColor();

            Thread.Sleep(4000);

            return true;            
        }

        public void LoggedIn(string username)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nInloggning lyckades!");
            Console.ResetColor();

            Thread.Sleep(2000);

            var loggedInUser = Users.UserList[username];

            
            if (loggedInUser.IsAdmin.Equals(true))
            {
                Admin loggedInAdmin = (Admin)loggedInUser;

                menu.AdminMenu(loggedInAdmin, Users);
            }

            else
            {
                Customer loggedInCustomer = (Customer)loggedInUser;
                menu.CustomerMenu(loggedInCustomer);
            }
        }
    }
}
