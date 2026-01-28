using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Application.Interfaces;
using PruebasApiSolid.Domain.Entities;
using BCrypt.Net;
namespace PruebasApiSolid.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<ResponseUser>> GetAll()
        {
          
        }

        public async Task<ResponseUser> GetId(Guid id)
        {
            var response = await _userRepository.GetId(id);

           
        }

        public async Task<ResponseUser> CreateUser(RequestUser requestUser)
        {
            
        }
    }
}
