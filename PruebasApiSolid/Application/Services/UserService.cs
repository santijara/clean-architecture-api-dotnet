using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Application.Interfaces;
using PruebasApiSolid.Domain.Entities;
using BCrypt.Net;
using PruebasApiSolid.Application.Common.Exceptions;
namespace PruebasApiSolid.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
  

        public async Task<ResponseUser> GetId(Guid id)
        {
            var response = await _userRepository.GetId(id);

            if (response == null) throw new NotFoundException();


            return new ResponseUser
            {
                Name = response.Name,
                Email = response.Email,
            };
        }
    }
}
