using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.EconomicsClasses
{
    public class Currency
    {
        //Variables for currency, so the amount and the name(sek, euro or pound)
        public double _Currency { get; set; }
        public string? _CurrencyName { get; set; }

        //Method for converting the currency depending on what the user inputs
        public double CurrencyConversion()
        {
            Console.WriteLine("Lägg till pengarna i sek");
            double amount;
            bool isRunning = true;
            //While-loop is there so that the program doesn't end if you put in a wrong input
            while (isRunning)
            {
                //TryParse exists so that the program doesn't crash if you input a non-double
                //If you put in a non-double you get an error message
                if (double.TryParse(Console.ReadLine(), out amount) == false)
                {
                    Console.WriteLine("Fel");
                }
                //If you put in a double, you get the rest of the program
                else
                {
                    Console.WriteLine($"Du har lagt in {amount} kr.\nVill du konvertera din summa till\n1. Euro/Pund\n2. Ha det i kr");
                    //Switch-case so you can choose between the options
                    string? choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Du har valt att ändra till Euro/Pund.\nVill du att valutan är i\n1. Euro\n2. Pund");
                            string? choice2 = Console.ReadLine();
                            switch (choice2)
                            {
                                case "1":
                                    Console.WriteLine("Euro");
                                    Console.WriteLine($"Du har {amount} kr");
                                    //Converts sek to euro which by 23/10/2025 1 kr = 0.092 euro
                                    amount = amount * 0.092;
                                    Console.WriteLine($"Du har {amount} euro");
                                    _Currency = amount;
                                    isRunning = false;
                                    break;
                                case "2":
                                    Console.WriteLine("Pund");
                                    Console.WriteLine($"Du har {amount} kr");
                                    //Converts sek to pound which by 23/10/2025 1 kr = 0.080 pounds
                                    amount = amount * 0.080;
                                    Console.WriteLine($"Du har {amount} pound");
                                    _Currency = amount;
                                    isRunning = false;
                                    break;
                                default:
                                    Console.WriteLine("Finns inte, välj mellan 1-2");
                                    break;
                            }
                            break;
                        case "2":
                            Console.WriteLine("Ha det i kr");
                            _Currency = amount;
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("Finns inte, välj mellan 1-2");
                        break;
                    }
                }                
            }
            return _Currency;
        }
    
        //TransactionCurrency methods that converts it from one currency to the other
        //These conversions might not be accurate in the future as this was made with the 23/10/2025 currencies in mind
        public double TCFromEuroToPound(double amount)
        {
            amount = amount * 0.86;
            return amount;
        }
        public double TCFromEuroToSek(double amount)
        {
            amount = amount * 10.87;
            return amount;
        }
        public double TCFromSekToEuro(double amount)
        {
            amount = amount * 0.092;
            return amount;
        }
        public double TCFromSekToPound(double amount)
        {
            amount = amount * 0.080;
            return amount;
        }
        public double TCFromPoundToEuro(double amount)
        {
            amount = amount * 1.15;
            return amount;
        }
        public double TCFromPoundToSek(double amount)
        {
            amount = amount * 12.55;
            return amount;
        }
    }
}
