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
        public decimal _Currency { get; set; }
        public string? _CurrencyName { get; set; }

        public decimal CalculateCurrency(string fromCurrencyCode, decimal fromCurrencyAmount, string toCurrencyCode)
        {
            //Gets the currency exchange rate from the given currencycodes from the method
            decimal currencyRate = getCurrencyExchangeRate(fromCurrencyCode, toCurrencyCode);
            //The result is rounded up to a whole number like t.ex 45.79 becomes 46.00
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
