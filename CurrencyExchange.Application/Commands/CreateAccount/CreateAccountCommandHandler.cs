using CurrencyExchange.Application.Commands.CreateCurrency;
using CurrencyExchange.Application.Dtos;
using CurrencyExchange.Domain.Entities;
using CurrencyExchange.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Commands.CreateAccount;
public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, AccountDto>
{
    private readonly IUserRepository _userRepositry;

    public CreateAccountCommandHandler(IUserRepository userRepositry)
    {
        _userRepositry = userRepositry;
    }

    public async Task<AccountDto> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
    {
        var account = new Account(command.AccountDto.Name);

        var user = await _userRepositry.GetAsync(x => x.Id == command.AccountDto.UserId, cancellationToken);

        if (user is null) throw new ValidationException($"User with id {command.AccountDto.UserId} not found");

        user?.AddAccount(account);

        await _userRepositry.SaveChangesAsync(cancellationToken);

        return new AccountDto(account.Id, account.Name, account.Balance);

    }
}