using Endeavours.DAL;
using Endeavours.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EndeavoursAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        ServiceRepository serviceRepository = new ServiceRepository();
        Service service = new Service();
        // GET: api/<ServiceController>
        [HttpGet]
        public string Get()
        {
            return  "value1";
        }

        // GET api/<ServiceController>/5
        [HttpGet("{id}")]
        public Service Get(int id)
        {
            service = serviceRepository.GetByID(id);
            return service;
        }

        // POST api/<ServiceController>
        [HttpPost]
        public void Post([FromBody] Service value)
        {
            serviceRepository.Insert(value);
        }

        // PUT api/<ServiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, Service service)
        {
            serviceRepository.Update(service,id);
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
