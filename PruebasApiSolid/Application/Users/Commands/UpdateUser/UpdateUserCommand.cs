using MediatR;
using PruebasApiSolid.Application.Common;
using PruebasApiSolid.Application.Dtos;

namespace PruebasApiSolid.Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(
        
        Guid Id,
        string Email     
        ): IRequest<Result<ResponseUser>>;
    
}
