using BankAppGrupp7.EconomicsClasses;
using BankAppGrupp7.MenuClasses;

namespace BankAppGrupp7
{
    internal class Program
    {
        static async Task Main(string[] args)
        {               
               
                await TransactionManager.Start();
            
            MainMenu.DisplayMainMenu();
        }
    }
}
