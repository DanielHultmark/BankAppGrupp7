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
        //Som systemägare vill jag att användare som misslyckas med inloggningen tre gånger ska låsas ute från att logga in i systemet.
        //Som systemägare vill jag att alla användare ska logga in med ett unikt användarnamn och lösenord.

        public int MaxLoginAttempts { get; set; } = 3;

        public UserRegister Users { get; set; } = new UserRegister();

        //OBS!
        //public Menu menu { get; set; } = new Menu();

        public void LoginUI()
        {
            bool stillEnteringLoginDetails = true;

            while (stillEnteringLoginDetails)
            {
                Console.Clear();

                Console.WriteLine("CIBA – där ekonomi möter innovation\n");
                Console.WriteLine("Fyll i inloggningsuppgifter");

                User currentUser = null;

                bool isLoginDetailsValid = AskForLoginDetails(currentUser);

                
                if (isLoginDetailsValid)
                {                    
                    stillEnteringLoginDetails = false;
                    LoggedIn(currentUser);
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
                Console.WriteLine();
                userInput = userInput.Trim();
            }

            return userInput;
        }

        public bool AskForLoginDetails(User currentUser)
        {
            string username = ReadInput("Användarnamn:");
            if (string.IsNullOrWhiteSpace (username))
            {
                return false;
            }          
          
            bool usernameExists = CheckUsername(username);

            if (usernameExists)
            {
                bool isLockedOut = CheckLoginAttempts(username);

                if (isLockedOut)
                {
                    return false;
                }

                string password = ReadInput("Lösenord:");

                if (string.IsNullOrWhiteSpace(password))
                {
                    return false;
                }
                                
                bool isPasswordCorrect = CheckPassword(username, password);

                if (isPasswordCorrect)
                {
                    currentUser = Users.UserList[username];
                }
                return isPasswordCorrect;
            }

            return false;
                         
        }

        public bool CheckUsername(string username)
        {
            bool usernameExists = Users.UserList.ContainsKey(username);

            if (!usernameExists)
            {
                Console.Write("Användarnamn saknas, försök igen!");

                Thread.Sleep(1000);
            }
            
            return usernameExists;

        }

        public bool CheckPassword(string username, string password)
        {
            bool isPasswordCorrect = false;

            if (Users.UserList.TryGetValue(username, out User user))
            {
                isPasswordCorrect = user.Password.Equals(password);

                if (!isPasswordCorrect)
                {
                    int attemptsLeft = MaxLoginAttempts - user.FailedLoginAttempts;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"Lösenordet är felaktigt, du har {attemptsLeft} försök kvar!");
                    Console.ResetColor();

                    user.IncreaseNumberLoginAttempts();

                    Thread.Sleep(2000);
                }
            }
            
            return isPasswordCorrect;
        }

        public bool CheckLoginAttempts(string username)
        {
            if (Users.UserList[username].FailedLoginAttempts == MaxLoginAttempts)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Användarkonto är låst pga för många inloggningsförsök. Kontakta kundtjänst för att låsa upp kontot.");
                Console.ResetColor();

                Thread.Sleep(5000);

                return true;
            }

            return false;
        }

        public void LoggedIn(User loggedInUser)
        {
            Console.WriteLine("\nInloggning lyckades!");

            Thread.Sleep(2000);

            //Testkod
            //Console.WriteLine($"Username: {loggedInUser.Username.PadRight(15)} Password: {loggedInUser.Password.PadRight(15)} Full name: {loggedInUser.FullName.PadRight(15)}");

            //OBS!
            //if (loggedInUser.IsAdmin.Equals(true))
            //{
            //    menu.AdminMenu(LoggedInUser);
            //}

            //else
            //{
            //    menu.CustomerMenu(loggedInUser);
            //}
        }
    }
}
