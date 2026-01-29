using MediatR;
using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Application.Interfaces;

namespace PruebasApiSolid.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersHandler
    : IRequestHandler<GetAllUsersQuery, IEnumerable<ResponseUser>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ResponseUser>> Handle(
            GetAllUsersQuery request,
            CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();

            return users.Select(u => new ResponseUser
            {
                Name = u.Name,
                Email = u.Email
            });
        }
    }

}
