using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Dtos;
public record CreateAccountDto
{
    public Guid UserId { get; set; }
    public string Name { get; set; }

    public CreateAccountDto(Guid userId, string name)
    {
        UserId = userId;
        Name = name;
    }
}
