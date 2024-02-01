using Microsoft.AspNetCore.Mvc;
using Smartdrive.DTO.Master;
using Smartdrive.Services.Master;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smartdrive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarBrandService _brandService;

        public CarController(ICarBrandService brandService)
        {
            _brandService = brandService;
        }

        // GET: api/<CarController>
        [HttpGet]
        public List<CarBrandResponse> Get()
        {
            return _brandService.FindAll();
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
