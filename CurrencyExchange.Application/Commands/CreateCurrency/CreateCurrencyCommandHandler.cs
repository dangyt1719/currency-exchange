using CurrencyExchange.Application.Commands.CreateUser;
using CurrencyExchange.Application.Dtos;
using CurrencyExchange.Domain.Entities;
using CurrencyExchange.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Commands.CreateCurrency;
public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand, CurrencyDto>
{
    private readonly ICurrencyRepository _currencyRepositry;

    public CreateCurrencyCommandHandler(ICurrencyRepository currencyRepository)
    {
        _currencyRepositry = currencyRepository;
    }

    public async Task<CurrencyDto> Handle(CreateCurrencyCommand command, CancellationToken cancellationToken)
    {
        var currency = new Currency(command.CurrencyDto.Name, command.CurrencyDto.Code );

        await _currencyRepositry.AddAsync(currency, cancellationToken);

        await _currencyRepositry.SaveChangesAsync(cancellationToken);

        return new CurrencyDto(currency.Id, currency.Name, currency.Code);

    }
}
