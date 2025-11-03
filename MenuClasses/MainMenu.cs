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
                Grafik.DisplayLogo();

                Console.Write("\n\nVälkommen till ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("CIBA - C# Investeringsbank AB!\n");
                Console.ResetColor();
                Console.Write("\n1. Logga in" + "\n2. Avsluta programmet");

                int choice = InputValidation.ReadIntInput("\nVälj:"); 

                switch (choice) 
                {
                    case 1:
                        start.LoginUI();
                        break;

                    case 2:
                        InputValidation.ShowFeedbackMessage("Avslutar program...", ConsoleColor.Red, 1000);
                        isRunning = false;
                        Environment.Exit(0);
                        break;

                    default:
                        InputValidation.ShowFeedbackMessage("Felaktigt val, försök igen.", ConsoleColor.Red, 1000);
                        break;
                }
            }
        }
       
    }
}
