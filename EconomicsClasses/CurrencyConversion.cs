using BankAppGrupp7.MenuClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.EconomicsClasses
{
    public static class CurrencyConversion
    {
        public static Currency Sek {  get; set; } = new Currency(CurrencyCode.SEK, 1);
        public static Currency Eur { get; set; } = new Currency(CurrencyCode.EUR, 10.87M);
        public static Currency Gbp { get; set; } = new Currency(CurrencyCode.GBP, 12.55M);

        public static Dictionary<Currency, decimal> Currencies { get; } 


        static CurrencyConversion()
        {
            Currencies = new Dictionary<Currency, decimal>
            {
                { Sek, Sek.SekToCurrencyRate },
                { Eur, Eur.SekToCurrencyRate },
                { Gbp, Gbp.SekToCurrencyRate }
            };            
        }
        public static void SetDailyExchangeRate()
        {
            Console.WriteLine("Sätt den dagliga växelkursen");
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine($"GBP kurs: {Gbp.SekToCurrencyRate:F2}");
                Console.WriteLine("Välj dagens kurs för GBP");
                decimal gbpRate = InputValidation.Decimal();
                Gbp.SekToCurrencyRate = gbpRate;
                Console.WriteLine($"EUR kurs: {Eur.SekToCurrencyRate:F2}");
                Console.WriteLine("Välj dagens kurs för EURO");
                decimal eurRate = InputValidation.Decimal();
                Eur.SekToCurrencyRate = eurRate;
                isRunning= false;
            }            
        }
        public static decimal ConvertCurrency(decimal amount, CurrencyCode fromCurrency, CurrencyCode toCurrency)
        {
            if (fromCurrency == toCurrency)
            {
                return amount;
            }            
            var fromEntry = Currencies.FirstOrDefault(c => c.Key.Code == fromCurrency);
            if (fromEntry.Key == null)
                throw new ArgumentException($"Okänd frånvaluta: {fromCurrency}");
            var fromRate = fromEntry.Value;

            var toEntry = Currencies.FirstOrDefault(c => c.Key.Code == toCurrency);
            if (toEntry.Key == null)
                throw new ArgumentException($"Okänd tillvaluta: {toCurrency}");
            var toRate = toEntry.Value;


            decimal amountInSek = amount * fromRate;

            decimal convertedAmount = amountInSek / toRate;

            return convertedAmount;
        }
       
    }
}
