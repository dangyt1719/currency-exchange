using CurrencyExchange.Application.Commands.CreateUser;
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

namespace CurrencyExchange.Application.Commands.CurrencyExchange;
public class CurrencyExchangeCommandHandler : IRequestHandler<CurrencyExchangeCommand>
{
    private readonly IUserRepository _userRepositry;

    public CurrencyExchangeCommandHandler(IUserRepository userRepositry)
    {
        _userRepositry = userRepositry;
    }

    public async Task Handle(CurrencyExchangeCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepositry.GetAsync(x=>x.Id==command.CurrencyExchangeDto.UserId, cancellationToken);

        if(user is null)  throw new ValidationException($"User with id {command.CurrencyExchangeDto.UserId} not found");

        if (!user.Accounts.Any(x => x.Id == command.CurrencyExchangeDto.AccountId)) throw new ValidationException($"User account with id {command.CurrencyExchangeDto.AccountId} not found");

        var account = user.Accounts.First(x => x.Id == command.CurrencyExchangeDto.AccountId);

        var exchangeAmount = account.Balance * command.CurrencyExchangeDto.Rate;

        var commissionAmount = (exchangeAmount * command.CurrencyExchangeDto.Сommission) / 100;

        account.IncreaseBalance(exchangeAmount - commissionAmount);

        await _userRepositry.SaveChangesAsync(cancellationToken);

    }
}
