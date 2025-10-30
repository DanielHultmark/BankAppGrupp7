using System;
using System.Collections.Generic;
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

                Console.WriteLine("Välkommen till CIBA - C# Investeringsbank AB!\n" +
                    "\n1. Logga in" +
                    "\n2. Avsluta programmet");

                int choice = InputValidation.ReadIntInput("\nVälj:");

                switch (choice) 
                {
                    case 1:
                        start.LoginUI();
                        break;

                    case 2:
                        Console.WriteLine("Avslutar program...");
                        Thread.Sleep(2000);
                        isRunning = false;
                        break;

                    default:
                        Console.Write("Felaktigt val, försök igen.");
                        break;
                }
            }
        }
       
    }
}
