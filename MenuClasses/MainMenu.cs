using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAppGrupp7.UsersClasses;

namespace BankAppGrupp7.MenuClasses
{
    internal class MainMenu
    {
        public static void DisplayMainMenu()
        {
            bool isRunning = true;
            LogIn start = new LogIn();
            
            while (isRunning)
            {

                Console.Clear();
                ConsoleUI.DisplayLogo();

                ConsoleUI.ShowHeader("CIBA - C# Investeringsbank AB");

                Console.Write("\n1. Logga in" + "\n2. Avsluta programmet");

                int choice = InputValidation.ReadIntInput("\nVälj:"); 

                switch (choice) 
                {
                    case 1:
                        start.LoginUI();
                        break;

                    case 2:
                        ConsoleUI.ShowFeedbackMessage("Avslutar program...", ConsoleColor.Red, 1000);
                        isRunning = false;                        
                        break;

                    default:
                        ConsoleUI.ShowFeedbackMessage("Felaktigt val, försök igen.", ConsoleColor.Red, 1000);
                        break;
                }
            }
        }
       
    }
}
