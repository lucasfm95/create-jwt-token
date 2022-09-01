using CreateJwtTokenApi.Core.Services.Interfaces;
using CreateJwtTokenApi.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreateJwtTokenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserModel model)
        {
            var user = _userService.FindUser(model);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = _userService.GenerateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet("Authenticated")]
        [Authorize(Roles = "employee")]
        public IActionResult Autenticated()
        {
            return Ok();
        }
    }
}
