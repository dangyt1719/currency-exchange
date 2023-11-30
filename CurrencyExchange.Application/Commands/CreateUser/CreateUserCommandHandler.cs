using CurrencyExchange.Application.Dtos;
using CurrencyExchange.Domain.Entities;
using CurrencyExchange.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Commands.CreateUser;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepositry;

    public CreateUserCommandHandler(IUserRepository userRepositry)
    {
        _userRepositry = userRepositry;
    }

    public async Task<UserDto> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = new User(command.UserDto.Name);

        await _userRepositry.AddAsync(user, cancellationToken);

        await _userRepositry.SaveChangesAsync(cancellationToken);

        return new UserDto(user.Id, user.Name);

    }
}
