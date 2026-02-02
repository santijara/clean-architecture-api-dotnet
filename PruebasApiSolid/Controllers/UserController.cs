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
    [Route("api/[controller]")]
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

            if (result.IsFailure)
                return NotFound(ApiResponse<string>.Fail(result.Error));

            return Ok(ApiResponse<IEnumerable<ResponseUser>>.Ok(result.Value));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _User.GetId(id);

            if (result.IsFailure)
                return NotFound(ApiResponse<ResponseUser>.Fail(result.Error));

            return Ok(ApiResponse<ResponseUser>.Ok(result.Value));
        }

        [HttpPost]
        public async Task<IActionResult>  CreateUser(CreateUserCommand request)
        {
            var result = await _mediator.Send(request);
            if (result.IsFailure)
                return BadRequest(ApiResponse<string>.Fail(result.Error));

            return Created(string.Empty,ApiResponse<ResponseUser>.Ok(result.Value)
     );
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
                return NotFound(ApiResponse<string>.Fail(result.Error));
            return Ok(ApiResponse<string>.Ok("Usuario eliminado correctamente"));

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UpdateRequestUser request)
        {
            var command = new UpdateUserCommand(id, request.Email);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
                return NotFound(ApiResponse<string>.Fail(result.Error));
            return Ok(ApiResponse<ResponseUser>.Ok(result.Value));
        }


    }
}
