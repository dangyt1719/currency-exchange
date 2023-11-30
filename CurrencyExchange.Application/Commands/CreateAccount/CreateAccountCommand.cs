using CurrencyExchange.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Commands.CreateAccount;
public class CreateAccountCommand : IRequest<AccountDto>
{
    public CreateAccountDto AccountDto { get; set; }
}
