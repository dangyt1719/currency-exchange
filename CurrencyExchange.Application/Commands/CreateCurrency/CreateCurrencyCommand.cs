using CurrencyExchange.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Commands.CreateCurrency;
public class CreateCurrencyCommand : IRequest<CurrencyDto>
{
    public CreateCurrencyDto CurrencyDto { get; set; }
}
