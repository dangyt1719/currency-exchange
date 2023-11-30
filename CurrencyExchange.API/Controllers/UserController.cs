using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using MediatR;
using CurrencyExchange.Application.Dtos;
using CurrencyExchange.Application.Commands.CreateUser;
using CurrencyExchange.Application.Commands.CreateAccount;
using CurrencyExchange.Application.Commands.CurrencyExchange;

namespace CurrencyExchange.API.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{

    private readonly IMediator _mediatr;
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediatr = mediator;
    }

    [HttpPost]
    public Task<UserDto> PostUser([FromBody] CreateUserDto userDto)
    {
        return _mediatr.Send(new CreateUserCommand { UserDto = userDto });
    }

    [HttpPost("/accounts")]
    public Task PostAccount([FromBody] CreateAccountDto accountDto)
    {
        return _mediatr.Send(new CreateAccountCommand { AccountDto = accountDto });
    }

    [HttpPost("/accounts/exchange")]
    public Task PostExchange([FromBody] CurrencyExchangeDto currencyExchangeDto)
    {
        return _mediatr.Send(new CurrencyExchangeCommand { CurrencyExchangeDto = currencyExchangeDto });
    }
}
