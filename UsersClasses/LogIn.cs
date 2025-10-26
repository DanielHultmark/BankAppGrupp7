using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.UsersClasses
{
    internal class LogIn
    {    
        public int MaxLoginAttempts { get; set; } = 3;

        public UserRegister Users { get; set; } = new UserRegister();

        //OBS!
        public Menu menu { get; set; } = new Menu();

        // The log in view refreshes if the user has given invalid input in some way. 
        // As it is now the only way to get out of the log in view is to give valid login details. 
        public void LoginUI()
        {
            bool stillEnteringLoginDetails = true;

            while (stillEnteringLoginDetails)
            {
                Console.Clear();

                Console.WriteLine("CIBA – där ekonomi möter innovation\n");
                Console.WriteLine("Fyll i inloggningsuppgifter");

                string username = ReadInput("Användarnamn:");

                bool usernameExists = CheckUsername(username);

                if (usernameExists)
                {
                    string password = ReadInput("Lösenord:");

                    bool isPasswordCorrect = CheckPassword(username, password);

                    if (isPasswordCorrect)
                    {
                        User currentUser = Users.UserList[username];

                        stillEnteringLoginDetails = false;

                        LoggedIn(currentUser);
                    }
                }                               
            }
        }

        public string ReadInput(string prompt)
        {
            Console.Write(prompt + " ");
            string? userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.Write("\nOgiltig input, försök igen!");
                userInput = " ";

                Thread.Sleep(1000);
            }

            else
            {                
                userInput = userInput.Trim();
            }

            return userInput;
        }
        
        public bool CheckUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return false;
            }

            bool usernameExists = Users.UserList.ContainsKey(username);

            if (!usernameExists)
            {
                Console.Write("Användarnamn saknas, försök igen!");

                Thread.Sleep(1000);

                return false;
            }

            bool isLockedOut = CheckLoginAttempts(username);

            if (isLockedOut)
            {
                return false;
            }

            return true;

        }

        //Should user be sent back to start menu when the account has been locked?
        public bool CheckPassword(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            bool isPasswordCorrect = false;

            if (Users.UserList.TryGetValue(username, out User user))
            {
                isPasswordCorrect = user.Password.Equals(password);

                if (!isPasswordCorrect)
                {
                    user.IncreaseNumberLoginAttempts();

                    int attemptsLeft = MaxLoginAttempts - user.FailedLoginAttempts;

                    Console.ForegroundColor = ConsoleColor.Red;

                    if (attemptsLeft>0)
                    {                        
                        Console.Write($"Lösenordet är felaktigt, du har {attemptsLeft} försök kvar!");

                        Thread.Sleep(2000);
                    }
                    
                    else
                    {
                        Console.Write($"Lösenordet är felaktigt, ditt användarkonto har nu låsts pga för många inloggningsförsök. " +
                                    $"\nKontakta kundtjänst för att låsa upp kontot.");

                        Thread.Sleep(5000);
                    }

                    Console.ResetColor();                    
                }
            }
            
            return isPasswordCorrect;
        }

        //Should user be sent back to start menu when the account is locked?
        public bool CheckLoginAttempts(string username)
        {
            if (Users.UserList[username].FailedLoginAttempts == MaxLoginAttempts)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nAnvändarkonto är låst pga för många inloggningsförsök. Kontakta kundtjänst för att låsa upp kontot.");
                Console.ResetColor();

                Thread.Sleep(5000);

                return true;
            }

            return false;
        }

        public void LoggedIn(User loggedInUser)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nInloggning lyckades!");
            Console.ResetColor();

            Thread.Sleep(2000);

            //OBS!
            if (loggedInUser.IsAdmin.Equals(true))
            {
                menu.AdminMenu(loggedInUser);
            }

            else
            {
                menu.CustomerMenu(loggedInUser);
            }
        }
    }
}
