using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Domain.Entities;
public class User
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    private List<Account> _accounts;

    public IReadOnlyList<Account> Accounts { get => _accounts; }

    public User(string  name)
    {
        Name = name;
        _accounts = new List<Account>();
    }

    public void AddAccount(Account account)
    {
        _accounts.Add(account);
    }

}
