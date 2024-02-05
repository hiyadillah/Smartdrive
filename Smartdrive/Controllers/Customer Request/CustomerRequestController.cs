using Microsoft.AspNetCore.Mvc;
using Smartdrive.DTO.Customer_Request;
using Smartdrive.Extension;
using Smartdrive.Services.Customer_Request;

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
        public async Task<ActionResult<ServiceResponse<CustomerRequestDto>>> GetCustomerRequestById(int id)
        {
            var response = await _service.GetCustomerRequestById(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        // POST api/<CustomerRequestController>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CustomerRequestDto>>> CreateCustomerRequest(AddCustomerRequestDto newRequest)
        {
            return Ok(await _service.CreateCustomerRequest(newRequest));
        }

        // PUT api/<CustomerRequestController>/5
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<CustomerRequestDto>>> UpdateCustomerRequest(UpdateCustomerRequestDto updatedRequest)
        {
            var response = await _service.UpdateCustomerRequest(updatedRequest);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        // DELETE api/<CustomerRequestController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<CustomerRequestDto>>> DeleteCustomerRequest(int id)
        {
            var response = await _service.DeleteCustomerRequest(id);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
