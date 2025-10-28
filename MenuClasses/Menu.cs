using BankAppGrupp7.AccountClasses;
using BankAppGrupp7.EconomicsClasses;
using BankAppGrupp7.UsersClasses;
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
        LogIn Login = new LogIn();
        Account Account = new Account();
        Currency Currency = new Currency();
        Admin admin = new Admin();
        Loan Loan = new Loan();
        //Kund menu
        public void CostrumerMenu()
        {           
            bool run = true;
            while (run)
            { 
                Console.Clear();
                Console.WriteLine("Welcome to the Bank Application!");
                Console.WriteLine("1. Skapa ett konto");
                Console.WriteLine("2. Kontoöversikt");
                Console.WriteLine("3. Lån översikt");
                Console.WriteLine("4. Ansök för ett Lån");
                Console.WriteLine("5. Logga ut");

                string choice = Console.ReadLine();

                switch (choice)
                {
                case "1":
                        Console.Clear();    
                        Account.CreateAccount();
                    break;
                case "2":
                        Console.Clear();
                        Account.ViewAccount();
                    break;
                case "3":
                        Console.Clear();
                        Loan.ViewLoans();
                    break;
                case "4":
                        Console.Clear();
                        Loan.ApplyForLoan();
                    break;
                case "5":
                    Console.WriteLine("Tack för att du använder Banken. Hejdå!");
                        Thread.Sleep(2000);
                        Console.Clear();
                        run = false;
                    break;
                default:
                    Console.WriteLine("Felaktigt val, Försök igen.");
                        Thread.Sleep(2000);
                        Console.Clear();
                        CostrumerMenu();
                        break;
                }
            }
            //Return to login menu after logging out
            Login.LoginUI();
        }
        //Admin menu
        public void AdminMenu()
        {
            
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("Admin Menu");
                Console.WriteLine("1. Skapa en Kund");
                Console.WriteLine("2. Kundöversikt");
                Console.WriteLine("3. Redera Kundkonto");
                Console.WriteLine("3. Sätt dagliga Valutakursen");
                Console.WriteLine("4. Logga ut");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        admin.CreateCustomer(Login.Users);
                        break;
                    case "2":
                        Console.Clear();
                        admin.ViewCustomers();
                        break;
                    case "3":
                        Console.Clear();
                        admin.DeleteCustomer(Login.Users);                        
                        break;
                    case "4":
                        Console.Clear();
                        Currency.SetDailyExchangeRates();
                        break;
                    case "5":
                        Console.WriteLine("Du Loggas nu ut. Hejdå!");
                        Thread.Sleep(2000);
                        Console.Clear();
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Felaktigt val, Försök igen.");
                        Thread.Sleep(2000);
                        Console.Clear();
                        AdminMenu();
                        break;
                }
            }
            //Return to login menu after logging out
            Login.LoginUI();
        }
    }
}
