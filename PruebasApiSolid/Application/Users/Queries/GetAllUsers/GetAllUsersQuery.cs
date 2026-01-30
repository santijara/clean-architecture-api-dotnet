using MediatR;
using PruebasApiSolid.Application.Common;
using PruebasApiSolid.Application.Dtos;

namespace PruebasApiSolid.Application.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery()
    : IRequest<Result<IEnumerable<ResponseUser>>>;
}
