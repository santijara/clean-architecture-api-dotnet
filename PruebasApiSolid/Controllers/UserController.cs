using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using PruebasApiSolid.Application.Common;
using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Application.Interfaces;
using PruebasApiSolid.Application.Users.Commands.CreateUser;
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

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
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
            //var response = await _userService.GetId(id);

            return Ok("OK");
        }

        [HttpPost]
        public async Task<IActionResult>  CreateUser(CreateUserCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(ApiResponse<object>.Ok(result));
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteUSer(Guid id)
        {
            //await _userService.DeleteUser(id);

            return Ok("OK");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand user)
        {
            var result = await _mediator.Send(user);
            return Ok(ApiResponse<object>.Ok(result));
        }

    }
}
