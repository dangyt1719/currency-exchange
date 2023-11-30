using CurrencyExchange.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Commands.CurrencyExchange;
public class CurrencyExchangeCommand : IRequest
{
    public CurrencyExchangeDto CurrencyExchangeDto { get; set; }
}
