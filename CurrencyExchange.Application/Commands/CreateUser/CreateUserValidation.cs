using CurrencyExchange.Application.Commands.CreateUser;
using CurrencyExchange.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Commands.CreateAccount;
public class CreateUserValidation : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidation()
    {
        RuleFor(x => x.UserDto.Name).NotEmpty().NotNull().Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("Correct currency name is required");
    }
}
