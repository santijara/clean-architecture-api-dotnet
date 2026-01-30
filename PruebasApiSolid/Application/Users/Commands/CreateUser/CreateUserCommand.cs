using MediatR;
using PruebasApiSolid.Application.Common;
using PruebasApiSolid.Application.Dtos;

namespace PruebasApiSolid.Application.Users.Commands.CreateUser
{
    public record CreateUserCommand(
    string Name,
    string Email,
    string Password
) : IRequest<Result<ResponseUser>>;
}
