using MediatR;
using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Domain.Entities;
using PruebasApiSolid.Infrastructure.Persistance;

namespace PruebasApiSolid.Application.Users.Commands.UpdateUser
{
    public class UpdateUserHandler: IRequestHandler<UpdateUserCommand, ResponseUser>
    {
        private readonly UserRepository _userRepository;

        public UpdateUserHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseUser> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var response = new User(command.Name, command.Email, command.Password);


        }
    }
}
