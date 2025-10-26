using BankAppGrupp7.MenuClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.EconomicsClasses
{
    public class Currency
    {
        //Variables for currency, so the currencyExchangeRate and the name(sek, euro or pound)
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

        public decimal CalculateCurrency(string fromCurrencyCode, decimal fromCurrencyAmount, string toCurrencyCode)
        {
            //Gets the currency exchange rate from the given currencycodes from the method
            decimal currencyRate = getCurrencyExchangeRate(fromCurrencyCode, toCurrencyCode);
            //The result is rounded up to a whole number like t.ex 45.79 becomes 46.00
            decimal conversionResult = currencyRate * fromCurrencyAmount;
            return conversionResult;
        }

        public void CalculateCurrencyTest()
        {
            //Method to test the other methods
            Console.WriteLine("Which currency do you want to choose from");
            string fromCurrencyCode = InputValidation.TrimmedString();
            Console.WriteLine("To which currency do you want to convert to");
            string toCurrencyCode = InputValidation.TrimmedString();
            Console.WriteLine("How much do you want to convert?");
            decimal fromCurrencyAmount = InputValidation.Decimal();
            decimal calculateCurrency = CalculateCurrency(fromCurrencyCode, fromCurrencyAmount, toCurrencyCode);
            Console.WriteLine(calculateCurrency);
        }
        private decimal getCurrencyExchangeRate(string fromCurrencyCode, string toCurrencyCode)
        {
            //This method is acting as a database for different currency exchange rates
            //If new currency exhange rates are to be added then new if/else if statement can be added
            decimal currencyExchangeRate;
            if (fromCurrencyCode == "kr" && toCurrencyCode == "euro")
            {
                currencyExchangeRate = (decimal)0.092;
                
            }
            else if (fromCurrencyCode == "euro" && toCurrencyCode == "kr")
            {
                currencyExchangeRate = (decimal)10.87;
            }
            else if (fromCurrencyCode == "kr" && toCurrencyCode == "pund")
            {
                currencyExchangeRate = (decimal)0.080;
            }
            else if (fromCurrencyCode == "pund" && toCurrencyCode == "kr")
            {
                currencyExchangeRate = (decimal)12.55;
            }
            else if (fromCurrencyCode == "euro" && toCurrencyCode == "pund")
            {
                currencyExchangeRate = (decimal)0.086;
            }
            else if (fromCurrencyCode == "pund" && toCurrencyCode == "euro")
            {
                currencyExchangeRate = (decimal)1.15;
            }
            else
            {
                currencyExchangeRate = 0;
            }
                return currencyExchangeRate;
        }
    }
}
