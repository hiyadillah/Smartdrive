using Microsoft.AspNetCore.Mvc;
using Smartdrive.DTO.Payment;
using Smartdrive.Services.Payment;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smartdrive.Controllers.Payment
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        // GET: api/<BankController>
        [HttpGet]
        public List<BankResponse> Get()
        {
            return _bankService.FindAll();
        }

        // GET api/<BankController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _bankService.FindById(id);
            if (data == null)
                return NotFound("User not found with the given ID");

            return Ok(data);
        }

        // POST api/<BankController>
        [HttpPost]
        public void Post(int bankEntityId, string bankName, string bankDesc)
        {
            _bankService.Create(bankEntityId, bankName, bankDesc);
        }

        // PUT api/<BankController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BankController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _bankService.FindById(id);
            if (data == null)
                return NotFound("User not found with the given ID");
            return Ok(_bankService.Delete(id));
        }
    }
}
