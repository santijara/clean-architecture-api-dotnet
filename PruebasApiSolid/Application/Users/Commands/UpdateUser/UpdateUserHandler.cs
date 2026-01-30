using MediatR;
using PruebasApiSolid.Application.Common.Exceptions;
using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Application.Interfaces;
using PruebasApiSolid.Domain.Entities;
using PruebasApiSolid.Infrastructure.Persistance;

namespace PruebasApiSolid.Application.Users.Commands.UpdateUser
{
    public class UpdateUserHandler: IRequestHandler<UpdateUserCommand, ResponseUser>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseUser> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var response = await _userRepository.GetId(command.Id);
            if (response == null) throw new NotFoundException();

            response.UpdateEmailUser(command.Email);

            await _userRepository.UpdateUser(response);

            return new ResponseUser
            {
                Email = command.Email,
                Name = response.Name
            };
        }
    }
}
