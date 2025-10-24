using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankAppGrupp7.UsersClasses
{
    internal class Admin : User
    {
        //Constructor; set IsAdmin to true
        public Admin()
        {
            IsAdmin = true;
        }

        public void CreateCustomer(UserRegister users)
        {
            Console.WriteLine("Lägg till ny kund");

            Console.Write("Användarnamn: ");
            string username = Console.ReadLine();

            Console.Write("Lösenord: ");
            string password = Console.ReadLine();

            Console.Write("För- och efternamn: ");
            string fullName = Console.ReadLine();
            
            users.AddCustomerInRegister(username, password, fullName);

        }

        public void DeleteCustomer(UserRegister users)
        {
            //Instruktioner för admin att ta bort en customer

            // Vilka argument ska DelteteCustomerInRegister() ta?

            users.DelteteCustomerInRegister();
        }

        public void CheckIfUniqueUsername()
        {
            //Help to check if username/password is unique when adding a customer, compare with already excisting in CustomerRegister
        }

        public void SetDailyExchangeRate(Currecy currecy)
        {
            //UI till admin, skickar/sparar data till currency

        }

    }
}
