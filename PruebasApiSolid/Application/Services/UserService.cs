using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Application.Interfaces;
using PruebasApiSolid.Domain.Entities;
using BCrypt.Net;
using PruebasApiSolid.Application.Common.Exceptions;
using PruebasApiSolid.Application.Common;
namespace PruebasApiSolid.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
  

        public async Task<Result<ResponseUser>> GetId(Guid id)
        {
            var user = await _userRepository.GetId(id);

            if (user == null)
                return Result<ResponseUser>.Failure("Usurio no encontrado");

             var response = new ResponseUser
             {
                 Name = user.Name.Value,
                 Email = user.Email.Value,
             };

            return Result<ResponseUser>.Success(response);
        }
    }
}
