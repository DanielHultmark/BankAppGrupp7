using System;
using System.Collections.Generic;

public abstract class Account
{
    public string AccountNumber { get; set; }
    public Customer Owner { get; set; }
    public decimal Balance { get; set; }
    public Currency Currency { get; set; }
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();

    public Account(string accountNumber, Customer owner, decimal balance, Currency currency)
    {
        AccountNumber = accountNumber;
        Owner = owner;
        Balance = balance;
        Currency = currency;
    }

    public void ShowBalance()
    {
        Console.WriteLine($"Saldo för konto {AccountNumber}: {Balance} {Currency}");
    }

    public abstract void Deposit(decimal amount);
    public abstract void Withdraw(decimal amount);
}

public class Customer { }
public class Currency { }
public class Transaction { }