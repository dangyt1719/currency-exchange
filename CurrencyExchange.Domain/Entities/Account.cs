using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Domain.Entities;
public class Account
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }
    
    public decimal Balance { get; private set; }

    public Account(string name) 
    { 
        Name = name;
        Balance = 0;
    }

    public void IncreaseBalance(decimal amount)
    {
        Balance += amount;
    }
    public void DecreaseBalance(decimal amount)
    {
        Balance -= amount;
    }
}
