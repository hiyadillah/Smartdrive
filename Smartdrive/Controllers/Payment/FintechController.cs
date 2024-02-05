using Microsoft.AspNetCore.Mvc;
using Smartdrive.DTO.Payment;
using Smartdrive.Models;
using Smartdrive.Repositories;
using Smartdrive.Services.Payment;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smartdrive.Controllers.Payment
{
    [Route("api/[controller]")]
    [ApiController]
    public class FintechController : ControllerBase
    {
        private readonly IFintechService _fintService;

        public FintechController(IFintechService repo)
        {
            _fintService = repo;
        }

        // GET: api/<FintechController>
        [HttpGet]
        public List<FintechResponse> Get()

        {
            return _fintService.FindAll();
        }

        // GET api/<FintechController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _fintService.FindById(id);
            if (data == null)
                return NotFound("User not found with the given ID");

            return Ok(data);
        }

        // POST api/<FintechController>
        [HttpPost]
        public IActionResult Post(string fintName, string fintDesc)
        {
            _fintService.Create(fintName, fintDesc);
            return Ok("SuccesfullyCreated");
        }

        // PUT api/<FintechController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, string fintName, string fintDesc)
        {
            FintechResponse data = _fintService.FindById(id);
            if (data == null)
                return NotFound("User not found with the given ID");
            _fintService.Update(data.fintEntityId, fintName, fintDesc);
            return Ok("Data Changed");
        }

        // DELETE api/<FintechController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _fintService.FindById(id);
            if (data == null)
                return NotFound("User not found with the given ID");
            _fintService.Delete(id);
            return Ok("Delete Succesfull");
        }
    }
}