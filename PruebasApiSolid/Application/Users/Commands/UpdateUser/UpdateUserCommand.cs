using MediatR;
using PruebasApiSolid.Application.Dtos;

namespace PruebasApiSolid.Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(
        
        string Name,
        string Email,
        string Password
        
        ): IRequest<ResponseUser>;
    
}
