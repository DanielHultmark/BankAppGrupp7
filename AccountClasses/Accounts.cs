using BankAppGrupp7.EconomicsClasses;
using BankAppGrupp7.UsersClasses;

namespace BankAppGrupp7.AccountClasses
{
    public abstract class Account
    {
        public string AccountNumber { get; set; }
        public Customer Owner { get; set; }
        public decimal Balance { get; set; }
        public Currency Currency { get; set; }
        public List<Transaction> Transactions { get; set; } = new();

        public Account(string accountNumber, Customer owner, decimal balance, Currency currency)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = balance;
            Currency = currency;
        }

        public abstract void Deposit(decimal amount);
        public abstract void Withdraw(decimal amount);
    }
}