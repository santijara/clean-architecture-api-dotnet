using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using PruebasApiSolid.Application.Common;
using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Application.Interfaces;
using PruebasApiSolid.Application.Users.Commands.CreateUser;
using PruebasApiSolid.Application.Users.Commands.DeleteUser;
using PruebasApiSolid.Application.Users.Commands.UpdateUser;
using PruebasApiSolid.Application.Users.Queries.GetAllUsers;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PruebasApiSolid.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _User;

        public UserController(IMediator mediator, IUserService service)
        {
            _mediator = mediator;
            _User = service;
        }
     
        [HttpGet]
        public  async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Ok(ApiResponse<object>.Ok(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _User.GetId(id);

            return Ok(ApiResponse<ResponseUser>.Ok(result));
        }

        [HttpPost]
        public async Task<IActionResult>  CreateUser(CreateUserCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(ApiResponse<object>.Ok(result));
        }

        [HttpDelete("Delete")]

        public async Task<IActionResult> DeleteUSer(DeleteUserCommand id)
        {
            var result = await _mediator.Send(id);

            return Ok(ApiResponse<ResponseDeleteUser>.Ok(result));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand user)
        {
            var result = await _mediator.Send(user);
            return Ok(ApiResponse<object>.Ok(result));
        }

    }
}
