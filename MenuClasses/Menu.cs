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
    public class Menu
    {
        CustomerUI CustomerUI = new CustomerUI();
        // Alla metoder är ännu inte implementerade och kan behöva uppdateras. DeleteCustomer behöver ta bort parameter username i Admin.

        //Customer menu
        public void CustomerMenu(Customer loggedInCustomer)
        {
            bool isRunnning = true;
            while (isRunnning)
            {
                Console.Clear();

                Design.ShowHeader($"Välkommen {loggedInCustomer.FullName}");
                Console.WriteLine("1. Skapa ett konto");
                Console.WriteLine("2. Kontoöversikt");
                Console.WriteLine("3. Låneöversikt");
                Console.WriteLine("4. Ansök om lån");
                Console.WriteLine("5. Logga ut");
                
                int choice = InputValidation.ReadIntInput("\nVälj:");

                switch (choice)
                {
                case 1:
                        Console.Clear();
                        CustomerUI.CreateAccount(loggedInCustomer);
                        Design.ReturnToMenu();

                    break;

                case 2:
                        Console.Clear();
                        CustomerUI.ViewAccount(loggedInCustomer);
                        Design.ReturnToMenu();

                    break;

                case 3:
                        Console.Clear();
                        CustomerUI.ViewLoans(loggedInCustomer);
                        Design.ReturnToMenu();

                    break;

                case 4:
                        Console.Clear();
                        CustomerUI.ApplyForLoan(loggedInCustomer);
                        Design.ReturnToMenu();

                    break;

                case 5:
                    Design.ShowFeedbackMessage("Du loggas ut från ditt konto!", ConsoleColor.Yellow, 2000);
                        Thread.Sleep(2000);
                        Console.Clear();
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

                Design.ShowHeader($"Välkommen {loggedInAdmin.FullName}");
                Console.WriteLine("1. Kundöversikt ");
                Console.WriteLine("2. Lägg till en kund");
                Console.WriteLine("3. Ta bort en kund");
                Console.WriteLine("4. Sätt dagens valutakurs");
                Console.WriteLine("5. Logga ut");
                
                int choice = InputValidation.ReadIntInput("\nVälj:");

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        loggedInAdmin.ViewCustomers(allUsers);
                        Console.ReadKey();
                        Design.ReturnToMenu();
                        break;

                    case 2:
                        Console.Clear();
                        loggedInAdmin.CreateCustomer(allUsers);  
                        Design.ReturnToMenu();
                        break;
                                              
                    case 3:
                        Console.Clear();
                        loggedInAdmin.DeleteCustomer(allUsers);
                        Design.ReturnToMenu();
                        break;

                    // Fattas UI för sätta daily exchange rate
                    case 4:
                        Console.Clear();
                        var currencyConvert = new CurrencyConversion();
                        //currencyConvert.SetDailyExchangeRate();
                        Design.ReturnToMenu();
                        break;

                    case 5:
                        Design.ShowFeedbackMessage("Du loggas ut från adminkontot!", ConsoleColor.Yellow, 2000);
                        isRunning = false;
                        
                        break;

                    default:
                        Console.WriteLine("Felaktigt val, försök igen.");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }
            }

            //Return to main menu after logging out
            MainMenu.DisplayMainMenu();
        }
    }
}
