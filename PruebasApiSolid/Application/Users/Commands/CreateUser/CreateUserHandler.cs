using MediatR;
using PruebasApiSolid.Application.Common;
using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Application.Interfaces;
using PruebasApiSolid.Domain.Entities;

namespace PruebasApiSolid.Application.Users.Commands.CreateUser
{
    public class CreateUserHandler
     : IRequestHandler<CreateUserCommand, Result<ResponseUser>>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<ResponseUser>> Handle(CreateUserCommand request,CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email, request.Password);

            await _userRepository.CreateUser(user);

            var response = new ResponseUser
            {
                Name = user.Name,
                Email = user.Email
            };

            return Result<ResponseUser>.Success(response);
        }
    }
}
