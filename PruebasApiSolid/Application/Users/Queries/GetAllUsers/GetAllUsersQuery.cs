using MediatR;
using PruebasApiSolid.Application.Dtos;

namespace PruebasApiSolid.Application.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery()
    : IRequest<IEnumerable<ResponseUser>>;
}
