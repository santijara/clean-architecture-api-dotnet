using Microsoft.AspNetCore.Mvc;
using PruebasApiSolid.Application.Common;
using PruebasApiSolid.Application.Dtos;
using PruebasApiSolid.Application.Interfaces;
using System.Threading.Tasks;

namespace PruebasApiSolid.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
     
        [HttpGet]
        public  async Task<IActionResult> GetAll()
        {
            var response = await _userService.GetAll();
            return Ok(ApiResponse<IEnumerable<ResponseUser>>.Ok(response));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _userService.GetId(id);

            return Ok(ApiResponse<ResponseUser>.Ok(response));
        }

        [HttpPost]
        public async Task<IActionResult>  CreateUser(RequestUser request)
        {
            var response = await _userService.CreateUser(request);
            return Ok(ApiResponse<ResponseUser>.Ok(response));
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteUSer(Guid id)
        {
            await _userService.DeleteUser(id);

            return Ok(ApiResponse<string>.Ok("Usuario Eliminado"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UpdateRequestUser user)
        {
            var response =  await _userService.UpdateUser(id, user);

            return Ok(ApiResponse<ResponseUser>.Ok(response));
        }

    }
}
