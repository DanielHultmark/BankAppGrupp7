using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.MenuClasses
{
    internal class MainMenu
    {
        public void DisplayMainMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Välkommen till BankAppGrupp7! Vill du \n1. Logga in\n2. Avsluta programmet");
                string? choice = InputValidation.TrimmedString();
                switch (choice) 
                {
                    case "1":
                        //LoginMenu here
                        break;

                    case "2":
                        Console.WriteLine("Avslutar program...");
                        Thread.Sleep(5000);
                        isRunning = false;
                        break;
                }
            }
        }
       
    }
}
