using Microsoft.AspNetCore.Mvc;
using Smartdrive.DTO.Payment;
using Smartdrive.Models;
using Smartdrive.Services.Payment;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smartdrive.Controllers.Payment
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;

        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        // GET: api/<UserAccountsController>
        [HttpGet]
        public List<UserAccountResponse> Get()
        {
            return _userAccountService.FindAll();
        }

        // GET api/<UserAccountsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            UserAccountResponse data = _userAccountService.FindById(id);

            if (data == null)
            {
                // Return a 404 Not Found status code with a custom error message
                return NotFound("User not found with the given ID");
            }

            return Ok(data);
        }

        // POST api/<UserAccountsController>
        [HttpPost]
        public void Post(int id, string usacAccountNo, decimal usacDebet, decimal usacCredit, string usacType)
        {
            _userAccountService.Create(id, usacAccountNo, usacDebet, usacCredit, usacType);
        }

        // PUT api/<UserAccountsController>/5
        [HttpPut("{usacId}")]
        public IActionResult Put(int usacId, string usacAccountNo, decimal? usacDebet, decimal? usacCredit, UserAccountPayment usacType)
        {
            var data = _userAccountService.FindById(usacId);
            if (data == null)
                return NotFound("User not found with the given ID");
            var updated = _userAccountService.Update(usacId, usacAccountNo, usacDebet, usacCredit, usacType.ToString());
            return Ok(updated);
        }

        // DELETE api/<UserAccountsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _userAccountService.FindById(id);
            if (data == null)
                return NotFound("User not found with the given ID");
            _userAccountService.Delete(id);
            return Ok("Delete Succesfull");
        }
    }
}
