using CurrencyExchange.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Commands.CreateAccount;
public class CreateAccountValidation : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountValidation()
    {
        RuleFor(x => x.AccountDto.UserId).Must(x=>x!=Guid.Empty).WithMessage("Correct userId is required");
        RuleFor(x => x.AccountDto.Name).NotEmpty().NotNull().Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("Correct account name is required");
    }
}
