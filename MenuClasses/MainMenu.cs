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
            LogIn login = new LogIn();
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till BankAppGrupp7! Vill du \n1. Logga in\n2. Avsluta programmet");
                string? choice = InputValidation.TrimmedString();
                switch (choice) 
                {
                    case "1":
                        //LoginMenu here
                        break;

                    case "2":
                        Console.WriteLine("Avslutar program...");
                        Thread.Sleep(3000);
                        isRunning = false;
                        break;
                }
            }
        }
       
    }
}
