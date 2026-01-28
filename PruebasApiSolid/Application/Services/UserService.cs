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
            var response = await _userRepository.GetAll();

            return response.Select(x => new ResponseUser
            {
                Name = x.Name,
                Email = x.Email,

            });
        }

        public async Task<ResponseUser> GetId(Guid id)
        {
            var response = await _userRepository.GetId(id);

            if (response == null) return null;


            return new ResponseUser
            {
                Name = response.Name,
                Email = response.Email,
            };
        }

        public async Task<ResponseUser> CreateUser(RequestUser requestUser)
        {
            var password = BCrypt.Net.BCrypt.HashPassword(requestUser.Password);
            var validate = new User(requestUser.Name, requestUser.Email, password);

            await _userRepository.CreateUser(validate);

            return new ResponseUser
            {
                Name = requestUser.Name,
                Email = requestUser.Email,
            };
        }
    }
}
