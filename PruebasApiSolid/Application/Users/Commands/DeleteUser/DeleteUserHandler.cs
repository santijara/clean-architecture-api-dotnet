using MediatR;
using PruebasApiSolid.Application.Common;
using PruebasApiSolid.Application.Common.Exceptions;
using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Application.Interfaces;

namespace PruebasApiSolid.Application.Users.Commands.DeleteUser
{
    public class DeleteUserHandler: IRequestHandler<DeleteUserCommand, Result>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var response = await _userRepository.GetId(command.Id);

            if (response == null)
                return Result.Failure("Usuario no encontrado");

            await _userRepository.DeleteUser(response);

            return Result.Success();
        }
    }
}
