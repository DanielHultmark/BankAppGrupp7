using BankAppGrupp7.EconomicsClasses;
using BankAppGrupp7.UsersClasses;

namespace BankAppGrupp7.AccountClasses
{
    public class SalaryAccount : Account
    {
        public SalaryAccount(string accountNumber, Customer owner, decimal balance, Currency currency)
            : base(accountNumber, owner, balance, currency)
        {
        }

        public override void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                new Transaction(amount, this, this);
            }
        }

        public override void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                new Transaction(amount, this, this);
            }
            else
            {
                Console.WriteLine("Otillräckligt saldo.");
            }
        }

        public void DepositSalary(decimal salaryAmount)
        {
            if (salaryAmount > 0)
            {
                Balance += salaryAmount;
                new Transaction(salaryAmount, this, this);
            }
        }
    }
}