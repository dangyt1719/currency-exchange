using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Dtos;
public record CreateUserDto
{
    public string Name { get; set; }

    public CreateUserDto(string name) => Name = name;
}
