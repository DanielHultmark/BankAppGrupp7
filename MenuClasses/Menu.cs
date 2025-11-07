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

        //Customer menu
        public void CustomerMenu(Customer loggedInCustomer)
        {
            bool isRunnning = true;
            while (isRunnning)
            {
                Console.Clear();

                ConsoleUI.ShowHeader($"Välkommen {loggedInCustomer.FullName}");
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
                    ConsoleUI.ReturnToMenu();
                    break;

                case 2:
                    Console.Clear();
                    CustomerUI.ViewAccount(loggedInCustomer);                        

                    break;

                case 3:
                    Console.Clear();
                    CustomerUI.ViewLoans(loggedInCustomer);
                    ConsoleUI.ReturnToMenu();

                    break;

                case 4:
                    Console.Clear();
                    CustomerUI.ApplyForLoan(loggedInCustomer);
                    ConsoleUI.ReturnToMenu();

                    break;

                case 5:
                    ConsoleUI.ShowFeedbackMessage("Du loggas ut från ditt konto!", ConsoleColor.Yellow, 2000);                    
                    isRunnning = false;
                    break;

                default:
                    ConsoleUI.ShowFeedbackMessage("Felaktigt val, försök igen.", ConsoleColor.Red, 1500);                    
                    break;
                }
            }
        }

        //Admin menu
        public void AdminMenu(Admin loggedInAdmin, UserRegister allUsers)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                ConsoleUI.ShowHeader($"Välkommen {loggedInAdmin.FullName}");
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
                        ConsoleUI.ReturnToMenu();
                        break;

                    case 2:
                        Console.Clear();
                        loggedInAdmin.CreateCustomer(allUsers);  
                        ConsoleUI.ReturnToMenu();
                        break;
                                              
                    case 3:
                        Console.Clear();
                        loggedInAdmin.DeleteCustomer(allUsers);
                        ConsoleUI.ReturnToMenu();
                        break;

                    case 4:
                        Console.Clear();
                        CurrencyConversion.SetDailyExchangeRate();
                        ConsoleUI.ReturnToMenu();                        
                        break;

                    case 5:
                        ConsoleUI.ShowFeedbackMessage("Du loggas ut från adminkontot!", ConsoleColor.Yellow, 1500);
                        isRunning = false;                        
                        break;

                    default:
                        ConsoleUI.ShowFeedbackMessage("Felaktigt val, försök igen.", ConsoleColor.Red, 1500);                        
                        break;
                }
            }
        }
    }
}
