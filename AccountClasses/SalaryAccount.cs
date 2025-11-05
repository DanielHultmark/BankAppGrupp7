using BankAppGrupp7.EconomicsClasses;
using BankAppGrupp7.UsersClasses;

namespace BankAppGrupp7.AccountClasses
{
    public class SalaryAccount : Account
    {
        public SalaryAccount(string accountNumber, Customer owner, decimal balance, CurrencyCode currency)
            : base(accountNumber, owner, balance, currency)
        {
        }
        
    }
}