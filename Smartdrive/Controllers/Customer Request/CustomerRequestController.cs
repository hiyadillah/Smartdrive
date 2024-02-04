using Microsoft.AspNetCore.Mvc;
using Smartdrive.DTO.Customer_Request;
using Smartdrive.Extension;
using Smartdrive.Services.CustomerRequest;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smartdrive.Controllers.Customer_Request
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRequestController : ControllerBase
    {
        private readonly CustomerRequestService _service;

        public CustomerRequestController(CustomerRequestService service)
        {
            _service = service;
        }

        // GET: api/<CustomerRequestController>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CustomerRequestDto>>>> GetAllCustomerRequest()
        {
            return Ok(await _service.GetAllCustomerRequest());
        }

        // GET api/<CustomerRequestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerRequestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerRequestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerRequestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
