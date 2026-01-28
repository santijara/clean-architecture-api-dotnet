using PruebasApiSolid.Application.Dtos;

namespace PruebasApiSolid.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<ResponseUser>> GetAll();

        Task<ResponseUser> GetId(Guid id);

        Task<ResponseUser> CreateUser(RequestUser requestUser);
    }
}
