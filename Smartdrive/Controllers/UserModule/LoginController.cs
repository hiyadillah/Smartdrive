using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smartdrive.DTO.UserModule;
using Smartdrive.Helpers;
using Smartdrive.Models;
using Smartdrive.Services.UserModule;
using System.Security.Claims;

namespace Smartdrive.Controllers.UserModule
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly JwtHelper _jwtHelper;
        private readonly Mapper _mapper;

        public LoginController(IUserService userService, JwtHelper jwtHelper, IRefreshTokenService refreshTokenService, Mapper mapper)
        {
            _userService = userService;
            _jwtHelper = jwtHelper;
            _refreshTokenService = refreshTokenService;
            _mapper = mapper;
        }

        [AllowAnonymous]
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

            var accessToken = _jwtHelper.CreateToken(checkUser, userRoles);

            //refresh token with db
            var refreshToken = _refreshTokenService.GenerateRefreshToken(checkUser);
            SetRefreshToken(refreshToken);

            var response = new Dictionary<string, string>
            {
                { "accessToken", accessToken }
            };

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            RefreshToken getRefreshDb = _refreshTokenService.FindRefreshTokenByToken(refreshToken);

            if (getRefreshDb == null)
            {
                return Unauthorized("Invalid Token");
            }

            //get by jwt
            //string username = User.Claims.Where(x => x.Type == "username").FirstOrDefault().Value;
            //var getUser = _userService.FindUserByUsername(username);

            var getUser = _userService.GetUserById(getRefreshDb.RetoUserId);

            var userRoles = _userService.GetUserRoles(getUser.UserEntityid);

            if (getUser == null)
            {
                return Unauthorized();
            }

            if(!getUser.RefreshTokens.Contains(getRefreshDb))
            {
                return Unauthorized("Invalid Refresh Token");
            } else if(getRefreshDb.RetoExpireDate < DateTime.Now)
            {
                return Unauthorized("Refresh Token Expired");
            }

            string newToken = _jwtHelper.CreateToken(getUser, userRoles);
            var newRefreshToken = _refreshTokenService.GenerateRefreshToken(getUser);
            SetRefreshToken(newRefreshToken);

            return Ok(newToken);
        }

        private void SetRefreshToken(RefreshToken refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.RetoExpireDate,
            };

            Response.Cookies.Append("refreshToken", refreshToken.RetoToken, cookieOptions);
        }

    }
}
