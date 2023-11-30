using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Dtos;
public record CurrencyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }

    public CurrencyDto(Guid id, string name, string code)
    {
        Id = id;
        Name = name;
        Code = code;
    }

}
