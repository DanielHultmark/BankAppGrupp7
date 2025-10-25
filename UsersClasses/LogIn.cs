using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
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

        //Obs!
        public Menu menu { get; set; } = new Menu();

        public void LoginUI()
        {

            bool stillEnteringLoginDetails = true;

            while (stillEnteringLoginDetails)
            {
                Console.Clear();

                Console.WriteLine("CIBA – där ekonomi möter innovation\n");
                Console.WriteLine("Fyll i uppgifter för att logga in");

                Console.Write("Användarnamn: ");
                string? username = Console.ReadLine().Trim();

                Console.Write("Lösenord: ");
                string? password = Console.ReadLine().Trim();

                User currentUser = null;
                bool isLoginDetailsValid = ValidateLoginDetails(currentUser, username, password);

                //OBS! Stopp för gjort 3 loggin försök
                if (isLoginDetailsValid)
                {
                    stillEnteringLoginDetails = false;
                    LoggedIn(currentUser);
                }
            }
        }

       

        public bool ValidateLoginDetails(User CurrenUser, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Ogiltig input, försök igen!");
                Thread.Sleep(1000);
            }          
          
            bool usernameExists = CheckUsername(username);

            if (usernameExists)
            {
                User currentUser = Users.UserList.Find(u => u.LoginDetails["username"].Equals(username));
                bool isPasswordCOrrect = CheckPassword(currentUser, password);
                return true;
            }

            return false;
                         
        }

        public bool CheckUsername(string username)
        {
                bool usernameExists = false;

                foreach (var user in Users.UserList)
                {
                    usernameExists = user.LoginDetails.ContainsKey(username);

                    if (usernameExists)
                    {
                        break;
                    }
                }

                if (!usernameExists)
                {
                    Console.WriteLine("Användarnamn saknas, försök igen!");

                    Thread.Sleep(1000);
                }
            
            return usernameExists;

        }

        public bool CheckPassword(User currentUser, string password)
        {                                                   
                bool isPasswordCorrect = currentUser.LoginDetails["password"].Equals(password);

                if (!isPasswordCorrect)
                {
                int attemptsLeft = MaxLoginAttempts - currentUser.FailedLoginAttempts;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Lösenordet är felaktigt, du har {attemptsLeft} försök kvar!");
                    Console.ResetColor();

                    currentUser.IncreaseNumberLoginAttempts();

                    Thread.Sleep(2000);
            }
         

            return isPasswordCorrect;
        }

        public void LoggedIn(User LoggedInUser)
        {
            Console.WriteLine("Inloggning lyckades!");

            Thread.Sleep(2000);

            if (LoggedInUser.IsAdmin.Equals(true))
            {
                menu.AdminMenu(LoggedInUser);
            }

            else
            {
                menu.CustomerMenu(LoggedInUser);
            }
        }
    }
}
