using Microsoft.AspNetCore.Mvc;
using Smartdrive.Models;
using Smartdrive.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smartdrive.Controllers.Payment
{
    [Route("api/[controller]")]
    [ApiController]
    public class FintechController : ControllerBase
    {
        private readonly IRepository<Fintech> _repo;

        public FintechController(IRepository<Fintech> repo)
        {
            _repo = repo;
        }

        // GET: api/<FintechController>
        [HttpGet]
        public IEnumerable<Fintech> Get()
        {
            return _repo.FindAll();
        }

        // GET api/<FintechController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FintechController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FintechController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FintechController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
