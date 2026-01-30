using MediatR;
using PruebasApiSolid.Application.Common;
using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Application.Interfaces;

namespace PruebasApiSolid.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersHandler
    : IRequestHandler<GetAllUsersQuery,Result<IEnumerable<ResponseUser>>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<IEnumerable<ResponseUser>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();
            if (!users.Any())
                return Result<IEnumerable<ResponseUser>>.Failure("No hay usuarios registrados");


            var response = users.Select(user => new ResponseUser
            {
                Name = user.Name,
                Email = user.Email
            });

            return Result<IEnumerable<ResponseUser>>.Success(response);

        }
    }

}
