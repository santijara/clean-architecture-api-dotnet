using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Domain.Entities;

namespace PruebasApiSolid.Application.Interfaces
{
    public interface IUserService
    {
        Task<ResponseUser> GetId(Guid id);    
    }
}
