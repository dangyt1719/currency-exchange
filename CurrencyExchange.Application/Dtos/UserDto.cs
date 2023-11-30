using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Dtos;
public record UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public UserDto(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

}
