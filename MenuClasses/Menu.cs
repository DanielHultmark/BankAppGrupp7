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
        // Alla metoder är ännu inte implementerade och kan behöva uppdateras. DeleteCustomer behöver ta bort parameter username i Admin.

        //Customer menu
        public void CustomerMenu(Customer loggedInCustomer)
        {
            bool isRunnning = true;
            while (isRunnning)
            {
                Console.Clear();

                Console.WriteLine($"Välkommen {loggedInCustomer.FullName}\n!");
                Console.WriteLine("1. Skapa ett konto");
                Console.WriteLine("2. Kontoöversikt");
                Console.WriteLine("3. Låneöversikt");
                Console.WriteLine("4. Ansök om lån");
                Console.WriteLine("5. Logga ut");
                
                int choice = InputValidation.ReadIntInput("\nVälj:");

                switch (choice)
                {
                case 1:
                    BankRegister.CreateAccount(loggedInCustomer);
                    break;

                case 2:
                    BankRegister.ViewAccount(loggedInCustomer);
                    break;

                case 3:
                    BankRegister.ViewLoans(loggedInCustomer);
                    break;

                case 4:
                    BankRegister.ApplyForLoan(loggedInCustomer);
                    break;

                case 5:
                    Console.WriteLine("Du loggas ut från kontot!");
                    Thread.Sleep(2000);
                    isRunnning = false;
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

        //Admin menu
        public void AdminMenu(Admin loggedInAdmin, UserRegister allUsers)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine($"Välkommen {loggedInAdmin.FullName}\n!");
                Console.WriteLine("1. Kundöversikt ");
                Console.WriteLine("2. Lägg till en kund");
                Console.WriteLine("3. Ta bort en kund");
                Console.WriteLine("4. Sätt dagens valutakurs");
                Console.WriteLine("5. Logga ut");
                
                int choice = InputValidation.ReadIntInput("\nVälj:");

                switch (choice)
                {
                    case 1:
                        loggedInAdmin.ViewCustomers(allUsers);
                        
                        break;

                    case 2:
                        loggedInAdmin.CreateCustomer(allUsers);                        
                        break;
                                              
                    case 3:
                        loggedInAdmin.DeleteCustomer(allUsers);
                        break;

                    // Fattas UI för sätta daily exchange rate
                    case 4:
                        var currencyConvert = new CurrencyConversion();
                        currencyConvert.SetDailyExchangeRate();
                        break;

                    case 5:
                        Console.WriteLine("Du loggas ut!");
                        isRunning = false;
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
