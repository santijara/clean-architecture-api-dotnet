using MediatR;
using PruebasApiSolid.Application.Dtos;

namespace PruebasApiSolid.Application.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(
        Guid Id     
        ): IRequest<ResponseDeleteUser>;
   
}
