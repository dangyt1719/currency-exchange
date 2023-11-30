using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Domain.Entities;
public class Currency
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Code { get; private set; }

    public Currency(string  name, string code)
    {
        Name = name;
        Code = code;
    }
}
