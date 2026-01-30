using MediatR;
using PruebasApiSolid.Application.Common.Exceptions;
using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Application.Interfaces;

namespace PruebasApiSolid.Application.Users.Commands.DeleteUser
{
    public class DeleteUserHandler: IRequestHandler<DeleteUserCommand, ResponseDeleteUser>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseDeleteUser> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var response = await _userRepository.GetId(command.Id);

            if (response == null) throw new NotFoundException();

            await _userRepository.DeleteUser(response);

            return new ResponseDeleteUser
            {
                Message = "Registro Eliminado"
            };
        }
    }
}
