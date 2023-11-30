using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Dtos;
public record CreateCurrencyDto
{
    public string Name { get; set; }
    public string Code { get; set; }

    public CreateCurrencyDto(string name, string code)
    {
        Name = name;
        Code = code;
    }
}
