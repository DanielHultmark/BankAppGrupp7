using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BankAppGrupp7.UsersClasses;
using BankAppGrupp7.MenuClasses;
using BankAppGrupp7.AccountClasses;
using BankAppGrupp7.EconomicsClasses;

namespace BankAppGrupp7.MenuClasses
{
    internal class Menu
    {               
        public void CustomerMenu(Customer loggedInCustomer)
        {
            bool isRunnning = true;
            while (isRunnning)
            { 
                Console.WriteLine($"Välkommen {loggedInCustomer.FullName}!");
                Console.WriteLine("1. Skapa ett konto");
                Console.WriteLine("2. Kontoöversikt");
                Console.WriteLine("3. Lån översikt");
                Console.WriteLine("4. Ansök för ett Lån");
                Console.WriteLine("5. Logga ut");
           
                // Hur felhantera? Parsa till int, skapa metod för int-input. 
                string choice = Console.ReadLine();

                switch (choice)
                {
                case "1":
                    BankRegister.CreateAccount(loggedInCustomer);
                    break;
                case "2":
                    BankRegister.ViewAccount(loggedInCustomer);
                    break;
                case "3":
                    BankRegister.ViewLoans(loggedInCustomer);
                    break;
                case "4":
                    BankRegister.ApplyForLoan(loggedInCustomer);
                    break;
                case "5":
                    Console.WriteLine("Du loggas ut från kontot!");
                    Thread.Sleep(2000);

                    isRunnning = false;
                    break;
                default:
                    Console.WriteLine("Felaktigt val, försök igen.");                    
                    break;
                }
            }
            //Return to main menu after logging out
            MainMenu.DisplayMainMenu();
        }

        //Admin menu
        public void AdminMenu(Admin loggedInAdmin, UserRegister allUsers)
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine($"Välkommen {loggedInAdmin.FullName}!");
                Console.WriteLine("1. Lägg till en kund");
                Console.WriteLine("2. Kundöversikt");
                Console.WriteLine("3. Ta bort en kund");
                Console.WriteLine("4. Sätt dagliga valutakursen");
                Console.WriteLine("5. Logga ut");

                Console.Write("Välj: ");
                            
                //Felhantering
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        loggedInAdmin.CreateCustomer(allUsers);
                        break;

                    case "2":
                        loggedInAdmin.ViewCustomers(allUsers);
                        break;
                    // Fattas UI för sätta daily exchange rate
                    case "3":
                        var currencyConvert = new CurrencyConversion();
                        currencyConvert.SetDailyExchangeRate();
                        break;

                    case "4":
                        Console.WriteLine("Du loggas ut!");
                        run = false;
                        break;

                    default:
                        Console.WriteLine("Felaktigt val, försök igen.");
                        Thread.Sleep(2000);
                        break;
                }
            }
            //Return to main menu after logging out
            MainMenu.DisplayMainMenu();
        }
    }
}
