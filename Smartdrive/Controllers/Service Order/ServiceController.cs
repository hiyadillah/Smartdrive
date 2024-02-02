using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smartdrive.DTO.Service_Order;
using Smartdrive.Models;
using Smartdrive.Repositories;
using Smartdrive.Repositories.Service_Order;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smartdrive.Controllers.Service_Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceRepository _serviceRepository;
        private readonly Mapper _mapper;

        public ServiceController(ServiceRepository serviceRepository, Mapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        // GET: api/<ServiceController>
        [HttpGet]
        public IResult Get()
        {
            var allService = _serviceRepository.FindAll();
            
            if (allService == null)
                return Results.NoContent();

            List<ServiceDto> ret=new();
            foreach (Service item in allService)
            {
                ret.Add(_mapper.Map<ServiceDto>(item));
            }
            return Results.Ok(ret);
        }

        // GET api/<ServiceController>/5
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            Service res = _serviceRepository.FindById(id);
            if (res == null)
                return Results.NoContent();
            
            ServiceDto result = _mapper.Map<ServiceDto>(res);
            
            return Results.Ok(result);
        }

        // POST api/<ServiceController>
        [HttpPost]
        public IResult Post([FromBody] ServiceDto value)
        {
            var res = _serviceRepository.Create(value);
            if(res==0)
                return Results.Problem("The operation has failed to be carried out");
            return Results.CreatedAtRoute();
        }

        // PUT api/<ServiceController>/5
        [HttpPut("{id}")]
        public IResult Put(int id,[FromBody] ServiceDto value)
        {
            var res = _serviceRepository.Update(id, value);
            if(res==0)
                return Results.Problem("The operation has failed to be carried out");
            return Results.CreatedAtRoute();
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public IResult Delete(dynamic id)
        {
            return Results.StatusCode(503);
        }
    }
}
