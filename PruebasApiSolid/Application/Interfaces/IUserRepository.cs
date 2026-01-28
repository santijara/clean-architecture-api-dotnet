using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Domain.Entities;

namespace PruebasApiSolid.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();

        Task<User?> GetId(Guid Id);
        Task CreateUser(User request);

        Task DeleteUser(User Id);

        Task UpdateUser(User user);
    }
}
