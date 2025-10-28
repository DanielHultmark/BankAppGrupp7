using BankAppGrupp7.MenuClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.EconomicsClasses
{
    internal class CurrencyConversion
    {
        public decimal CalculateCurrency(string fromCurrencyCode, decimal fromCurrencyAmount, string toCurrencyCode)
        {
            //Gets the currency exchange rate from the given currencycodes from the method
            decimal currencyRate = getCurrencyExchangeRate(fromCurrencyCode, toCurrencyCode);
            //The result is rounded up to a number with decimals
            decimal conversionResult = decimal.Multiply(currencyRate, fromCurrencyAmount);
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
            //If you misspell or get it wrong then your currency exchange rate will become 0
            decimal currencyExchangeRate;
            if (fromCurrencyCode == "sek" && toCurrencyCode == "euro")
            {
                currencyExchangeRate = (decimal)0.092;

            }
            else if (fromCurrencyCode == "euro" && toCurrencyCode == "sek")
            {
                currencyExchangeRate = (decimal)10.87;
            }
            else if (fromCurrencyCode == "kr" && toCurrencyCode == "pund")
            {
                currencyExchangeRate = (decimal)0.080;
            }
            else if (fromCurrencyCode == "pund" && toCurrencyCode == "sek")
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

        //Changes the currency exchange rate that only admins have access to
        public decimal SetDailyExchangeRate(string fromCurrencyCode, string toCurrencyCode)
        {
            //Has two decimals for the currency exchange rate and then the change that the admin puts in
            decimal currencyexchangeChange;
            decimal currencyExchangeRate;
            //Checks if the fromCurrencyCode and toCurrencyCode are valid 
            if (fromCurrencyCode == "sek" && toCurrencyCode == "euro")
            {
                Console.WriteLine($"From {fromCurrencyCode} to {toCurrencyCode}\nCurrent difference is 1 sek is 0.092 euro\nWhat do you want to change it to?");
                currencyexchangeChange = InputValidation.Decimal();
                //InputValidation is there so you can't put in strings or null
                currencyExchangeRate = (decimal)currencyexchangeChange;

            }
            else if (fromCurrencyCode == "euro" && toCurrencyCode == "sek")
            {
                Console.WriteLine($"From {fromCurrencyCode} to {toCurrencyCode}\nCurrent difference is 1 euro is 10.87 sek\nWhat do you want to change it to?");
                currencyexchangeChange = InputValidation.Decimal();
                currencyExchangeRate = (decimal)currencyexchangeChange;
            }
            else if (fromCurrencyCode == "kr" && toCurrencyCode == "pund")
            {
                Console.WriteLine($"From {fromCurrencyCode} to {toCurrencyCode}\nCurrent difference is 1 sek is 0.080 pound\nWhat do you want to change it to?");
                currencyexchangeChange = InputValidation.Decimal();
                currencyExchangeRate = (decimal)currencyexchangeChange;
            }
            else if (fromCurrencyCode == "pund" && toCurrencyCode == "sek")
            {
                Console.WriteLine($"From {fromCurrencyCode} to {toCurrencyCode}\nCurrent difference is 1 pound is 12.55 sek\nWhat do you want to change it to?");
                currencyexchangeChange = InputValidation.Decimal();
                currencyExchangeRate = (decimal)currencyexchangeChange;
            }
            else if (fromCurrencyCode == "euro" && toCurrencyCode == "pund")
            {
                Console.WriteLine($"From {fromCurrencyCode} to {toCurrencyCode}\nCurrent difference is 1 euro is 0,086 pund\nWhat do you want to change it to?");
                currencyexchangeChange = InputValidation.Decimal();
                currencyExchangeRate = (decimal)currencyexchangeChange;
            }
            else if (fromCurrencyCode == "pund" && toCurrencyCode == "euro")
            {
                Console.WriteLine($"From {fromCurrencyCode} to {toCurrencyCode}\nCurrent difference is 1 pound is 1.15 euro\nWhat do you want to change it to?");
                currencyexchangeChange = InputValidation.Decimal();
                currencyExchangeRate = (decimal)currencyexchangeChange;
            }
            //If the names of the values aren't valid then you get nothing
            else
            {
                currencyExchangeRate = 0;
            }
            return currencyExchangeRate;
        }
    }
}
