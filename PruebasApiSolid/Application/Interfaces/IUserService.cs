using PruebasApiSolid.Application.Common;
using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Domain.Entities;

namespace PruebasApiSolid.Application.Interfaces
{
    public interface IUserService
    {
        Task<Result<ResponseUser>> GetId(Guid id);    
    }
}
