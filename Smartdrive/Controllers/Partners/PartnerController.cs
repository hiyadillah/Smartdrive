using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Smartdrive.DTO.Partners;
using Smartdrive.Helper;
using Smartdrive.Services.Partners;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smartdrive.Controllers.Partners
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService _partnerService;

        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] PaginationRequest request)
        {
            var pagination = await _partnerService.Paginate(request);
            return Ok(pagination);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PartnerRequest request)
        {
            await _partnerService.Create(request);
            HttpContext.Response.StatusCode = (int) HttpStatusCode.Created;
            return new EmptyResult();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PartnerRequest request)
        {
            await _partnerService.Update(request, id);
            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _partnerService.Delete(id);
            return NoContent();
        }
    }
}
