using Microsoft.AspNetCore.Mvc;
using Smartdrive.DTO.Partners;
using Smartdrive.Services.Partners;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smartdrive.Controllers.Partners
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerContactController : ControllerBase
    {
        private readonly IPartnerContactService _partnerContactService;

        public PartnerContactController(IPartnerContactService partnerContactService)
        {
            _partnerContactService = partnerContactService;
        }

        // GET: api/<PartnerContactController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PartnerContactController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PartnerContactController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PartnertContactRequest request)
        {
            await _partnerContactService.Create(request);
            HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
            return new EmptyResult();
        }

        // PUT api/<PartnerContactController>/5
        [HttpPut("{partnerId:int}/{userId:int}")]
        public async Task<ActionResult> Put(int partnerId, int userId, [FromBody] UpdatePartnerContactRequest request)
        {
            await _partnerContactService.Update(partnerId, userId, request);
            return Ok();
        }

        // DELETE api/<PartnerContactController>/5
        [HttpDelete("{partnerId:int}/{userId:int}")]
        public async Task<ActionResult> Delete(int partnerId, int userId)
        {
            await _partnerContactService.Delete(partnerId, userId);
            return NoContent();
        }
    }
}
