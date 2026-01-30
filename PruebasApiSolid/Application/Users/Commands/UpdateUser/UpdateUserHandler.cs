using MediatR;
using PruebasApiSolid.Application.Common;
using PruebasApiSolid.Application.Common.Exceptions;
using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Application.Interfaces;
using PruebasApiSolid.Domain.Entities;
using PruebasApiSolid.Infrastructure.Persistance;

namespace PruebasApiSolid.Application.Users.Commands.UpdateUser
{
    public class UpdateUserHandler: IRequestHandler<UpdateUserCommand, Result<ResponseUser>>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<ResponseUser>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetId(command.Id);
            if (user == null) 
              return Result<ResponseUser>.Failure("Usuario no existe");

            user.UpdateEmailUser(command.Email);

            await _userRepository.UpdateUser(user);

            var response = new ResponseUser
            {
                Email = user.Email,
                Name = user.Name
            };

            return Result<ResponseUser>.Success(response);
        }
    }
}
