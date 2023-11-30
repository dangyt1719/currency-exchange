using CurrencyExchange.Application.Dtos;
using MediatR;
using System.Windows.Input;

namespace CurrencyExchange.Application.Commands.CreateUser;
public record CreateUserCommand : IRequest<UserDto>
{
    public CreateUserDto UserDto { get; set; }
}
