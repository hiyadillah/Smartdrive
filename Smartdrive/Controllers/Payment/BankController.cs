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
        public IActionResult Post(int bankEntityId, string bankName, string bankDesc)
        {
            _bankService.Create(bankEntityId, bankName, bankDesc);
            return Ok("SuccesfullyCreated");
        }

        // PUT api/<BankController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, string bankName, string bankDesc)
        {
            BankResponse data = _bankService.FindById(id);
            if (data == null)
                return NotFound("User not found with the given ID");
            _bankService.Update(data.bankEntityId, bankName, bankDesc);
            return Ok("Data Changed");
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
