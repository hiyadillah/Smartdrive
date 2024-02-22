using Microsoft.AspNetCore.Mvc;
using Smartdrive.DTO.Customer_Request.Response;
using Smartdrive.Models;
using Smartdrive.Repositories;
using Smartdrive.Repositories.Customer_Request.Contract;
using Smartdrive.Services.Customer_Request.Contract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smartdrive.Controllers.Customer_Request
{
	[Route("api/customer/service")]
	[ApiController]
	public class CustomerRequestController : ControllerBase
	{
		private readonly ICustomerRequestService _customerRequestService;

		public CustomerRequestController(ICustomerRequestService customerRequestService)
		{
			_customerRequestService = customerRequestService;
		}

		// GET: api/<CustomerController>
		[HttpGet("request")]
		public async Task<ActionResult<List<CustomerReqResponse>>> GetAllCustomerRequest(int id, string arwgCode, string role)
		{
			List<CustomerReqResponse> result = new();

			if (role == "Customer")
			{
				result = await _customerRequestService.GetAllByCustomer(id);

			}
			else if (role == "Employee")
			{
				result = await _customerRequestService.GetAllByEmployee(arwgCode);
			}
			return Ok(result);
		}

		// GET api/<CustomerController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult> Get(int id)
		{
			var response = await _customerRequestService.Get(id);
			if (response == null)
				return NotFound($"Customer Request with the given id is not found.");
			return Ok(response);
		}

		// POST api/<CustomerController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<CustomerController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<CustomerController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
