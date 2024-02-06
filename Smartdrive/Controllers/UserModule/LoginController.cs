using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smartdrive.DTO.UserModule;
using Smartdrive.Helpers;
using Smartdrive.Services.UserModule;

namespace Smartdrive.Controllers.UserModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtHelper _jwtHelper;

        public LoginController(IUserService userService, JwtHelper jwtHelper)
        {
            _userService = userService;
            _jwtHelper = jwtHelper;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest body)
        {
            var checkUser = _userService.FindUserByUsername(body.Username);
            if(checkUser == null)
            {
                return BadRequest("Incorrect username or password");
            }

            if (BCrypt.Net.BCrypt.Verify(body.Password, checkUser.UserPassword) == false) {
                return BadRequest("Incorrect username or password");
            }

            var userRoles = _userService.GetUserRoles(checkUser.UserEntityid);

            var token = _jwtHelper.CreateToken(checkUser, userRoles);

            var response = new Dictionary<string, string>
            {
                { "accessToken", token }
            };

            return Ok(response);
        }
        
    }
}
