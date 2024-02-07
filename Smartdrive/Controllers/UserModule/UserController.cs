using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smartdrive.DTO.UserModule;
using Smartdrive.Models;
using Smartdrive.Services.UserModule;

namespace Smartdrive.Controllers.UserModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _usersService;
        private readonly Mapper _mapper;
        public UserController(IUserService usersService, Mapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        [Authorize(Roles = "PC, CU")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _usersService.GetUsers();
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var user = _usersService.GetUserById(id);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }
        }

        [HttpPost]
        public IActionResult RegisterEmployee(UserRequest user)
        {
            try
            {
                var newUser = _usersService.CreateEmployee(user);

                return Ok(newUser);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }
        }

        [HttpPost("assign-role/{id}")]
        public IActionResult UserAssignRole(int id, string userRole)
        {
            try
            {
                var userRoles = _usersService.GetUserRoles(id);

                var containRoles = userRoles.Any(x => x.UsroRoleName == userRole);
                
                if(containRoles)
                    return BadRequest($"User already has {userRole} role");

                var assignRole = _usersService.AssignUserRole(id, userRole);

                return Ok("Role assigned");

            }
            catch (Exception)
            {
                return StatusCode(500);

            }
        }

        [HttpGet("roles/{id}")]
        public IActionResult GetUserRoles(int id)
        {
            try
            {
                var userRoles = _usersService.GetUserRoles(id);

                return Ok(userRoles);

            }
            catch (Exception)
            {
                return StatusCode(500);

            }
        }
    }
}
