using Microsoft.AspNetCore.Mvc;
using Smartdrive.DTO.Partners;
using Smartdrive.Helper;
using Smartdrive.Models;
using Smartdrive.Services.Partners;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smartdrive.Controllers.Partners
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatnerAreaWorkgroupController : ControllerBase
    {
        private readonly IPartnerAreaWorkgroupService _partnerAreaWorkgroupService;

        public PatnerAreaWorkgroupController(IPartnerAreaWorkgroupService partnerAreaWorkgroupService)
        {
            _partnerAreaWorkgroupService = partnerAreaWorkgroupService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<PaginationResponse<PartnerAreaWorkGroupAggregate>>> Get([FromQuery] PaginationRequest request)
        {
            var result = await _partnerAreaWorkgroupService.Paginate(request);
            return result;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PartnerAreaWorkgroupRequest request)
        {
            await _partnerAreaWorkgroupService.Create(request);
            HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
            return new EmptyResult();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{pawoPatrEntityid:int}/{pawoArwgCode}/{pawoUserEntityid:int}")]
        public async Task<ActionResult> Put(
            int pawoPatrEntityid, 
            int pawoUserEntityid, 
            string pawoArwgCode, 
            [FromBody] UpdatePartnerAreaWorkgroupRequest request
         )
        {
            await _partnerAreaWorkgroupService.Update(pawoPatrEntityid, pawoUserEntityid, pawoArwgCode, request);
            return Ok();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{pawoPatrEntityid:int}/{pawoArwgCode}/{pawoUserEntityid:int}")]
        public async Task<ActionResult> Delete(int pawoPatrEntityid, string pawoArwgCode, int pawoUserEntityid)
        {
            await _partnerAreaWorkgroupService.Delete(pawoPatrEntityid, pawoUserEntityid, pawoArwgCode);
            return Ok();
        }
    }
}
