using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Dtos;
public record AccountDto
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public decimal Balance { get; private set; }

    public AccountDto(Guid Id, string name, decimal balance)
    {
        Id = Id;
        Name = name;
        Balance = balance;
    }
}
