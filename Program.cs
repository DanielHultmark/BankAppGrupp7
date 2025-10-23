using BankAppGrupp7.EconomicsClasses;

namespace BankAppGrupp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Welcome to BankAppGrupp7!");
            Currency currency = new Currency();
            currency.CurrencyConversion();
        }
    }
}
