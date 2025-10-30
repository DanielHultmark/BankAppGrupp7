using BankAppGrupp7.EconomicsClasses;
using BankAppGrupp7.UsersClasses;

namespace BankAppGrupp7.AccountClasses
{
    internal class SalaryAccount : Account
    {
        public SalaryAccount(string accountNumber, Customer owner, decimal balance, Currency currency)
            : base(accountNumber, owner, balance, currency)
        {
        }
        public decimal Balance { get; set; }
    }
}