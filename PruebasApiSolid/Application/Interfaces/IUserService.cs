using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Domain.Entities;

namespace PruebasApiSolid.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<ResponseUser>> GetAll();

        Task<ResponseUser> GetId(Guid id);

        Task<ResponseUser> CreateUser(RequestUser requestUser);

        Task DeleteUser(Guid id);
    }
}
