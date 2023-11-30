using CurrencyExchange.Application.Commands.CreateCurrency;
using CurrencyExchange.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Commands.CreateAccount;
public class CreateCurrencyValidation : AbstractValidator<CreateCurrencyCommand>
{
    public CreateCurrencyValidation()
    {
        RuleFor(x => x.CurrencyDto.Code).NotEmpty().NotNull().Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("Correct currency code is required");
        RuleFor(x => x.CurrencyDto.Name).NotEmpty().NotNull().Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("Correct currency name is required");
    }
}
