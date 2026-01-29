using MediatR;
using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Application.Interfaces;
using PruebasApiSolid.Domain.Entities;

namespace PruebasApiSolid.Application.Users.Commands.CreateUser
{
    public class CreateUserHandler
     : IRequestHandler<CreateUserCommand, ResponseUser>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseUser> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email, request.Password);

            await _userRepository.CreateUser(user);

            return new ResponseUser
            {
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
