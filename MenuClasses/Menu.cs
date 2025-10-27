using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.MenuClasses
{
    internal class Menu
    {        
        //Kund menu
        public void CostrumerMenu()
        {
            Console.WriteLine("Welcome to the Bank Application!");
            Console.WriteLine("1. Skapa ett konto");
            Console.WriteLine("2. Kontoöversikt");
            Console.WriteLine("3. Lån översikt");
            Console.WriteLine("4. Ansök för ett Lån");
            Console.WriteLine("5. Logga ut");
            
            bool run = true;
            while (run)
            { 
                string choice = Console.ReadLine();

                switch (choice)
                {
                case "1":
                    Account.CreateAccount();
                    break;
                case "2":
                    Account.ViewAccount();
                    break;
                case "3":
                    Loan.ViewLoans();
                    break;
                case "4":
                    Loan.ApplyForLoan();
                    break;
                case "5":
                    Console.WriteLine("Tack för att du använder Banken. Hejdå!");
                    run = false;
                    break;
                default:
                    Console.WriteLine("Felaktigt val, Försök igen.");
                    DisplayMainMenu();
                    break;
                }
            }
            //Return to login menu after logging out
            Login.LoginMenu();
        }
        //Admin menu
        public void AdminMenu()
        {
            Console.WriteLine("Admin Menu");
            Console.WriteLine("1. Skapa en Kund");
            Console.WriteLine("2. Kundöversikt");
            Console.WriteLine("3. Sätt dagliga Valutakursen");
            Console.WriteLine("4. Logga ut");

            bool run = true;
            while (run)
            {
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        User.CreateCustomer();
                        break;
                    case "2":
                        User.ViewCustomers();
                        break;
                    case "3":
                        Currency.SetDailyExchangeRate();
                        break;
                    case "4":
                        Console.WriteLine("Du Loggas nu ut. Hejdå!");
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Felaktigt val, Försök igen.");
                        AdminMenu();
                        break;
                }
            }
            //Return to login menu after logging out
            Login.LoginMenu();
        }
    }
}
