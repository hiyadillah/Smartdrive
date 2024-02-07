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

		public CustomerRequestController(ICustomerRequestRepository customerRequestRepository, ICustomerRequestService customerRequestService)
		{
			_customerRequestService = customerRequestService;
		}

		// GET: api/<CustomerController>
		[HttpGet("request")]
		public async Task<ActionResult<List<CustomerReqResponse>>> GetAllCustomerRequest(int userEntityId, string arwgCode)
		{
			return Ok(await _customerRequestService.GetAll(userEntityId, arwgCode));
		}

		// GET api/<CustomerController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult> Get(int id)
		{
			return Ok(await _customerRequestService.Get(id));
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
