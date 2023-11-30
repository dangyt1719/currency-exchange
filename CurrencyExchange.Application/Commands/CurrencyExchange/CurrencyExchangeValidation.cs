using CurrencyExchange.Application.Commands.CurrencyExchange;
using CurrencyExchange.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Commands.CreateAccount;
public class CurrencyExchangeValidation : AbstractValidator<CurrencyExchangeCommand>
{
    public CurrencyExchangeValidation()
    {
        RuleFor(x => x.CurrencyExchangeDto.UserId).Must(x => x != Guid.Empty).WithMessage("Correct userId is required");
        RuleFor(x => x.CurrencyExchangeDto.AccountId).Must(x => x != Guid.Empty).WithMessage("Correct accountId is required");
        RuleFor(x => x.CurrencyExchangeDto.Rate).Must(x => x > 0).WithMessage("Correct currency rate is required");
        RuleFor(x => x.CurrencyExchangeDto.Amount).Must(x => x > 0).WithMessage("Correct amount is required");

    }
}
