using CurrencyExchange.Application.Commands.CreateAccount;
using CurrencyExchange.Application.Commands.CreateCurrency;
using CurrencyExchange.Application.Commands.CreateUser;
using CurrencyExchange.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.API.Controllers;

[ApiController]
[Route("currencies")]
public class CurrencyController : ControllerBase
{

    private readonly IMediator _mediatr;
    private readonly ILogger<UserController> _logger;

    public CurrencyController(ILogger<UserController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediatr = mediator;
    }

    [HttpPost]
    public Task<CurrencyDto> PostCurrency([FromBody] CreateCurrencyDto currencyDto)
    {
        return _mediatr.Send(new CreateCurrencyCommand { CurrencyDto = currencyDto });
    }
}

