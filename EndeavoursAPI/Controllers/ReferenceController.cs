using Endeavours.DAL;
using Endeavours.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EndeavoursAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceController : ControllerBase
    {
        ReferenceRepository referenceRepository = new ReferenceRepository();
        Reference reference = new Reference();
        // GET: api/<ReferenceController>
        [HttpGet]
        public string Get()
        {
            return  "value2" ;
        }

        // GET api/<ReferenceController>/5
        [HttpGet("{id}")]
        public Reference Get(int id)
        {
            reference = referenceRepository.GetByID(id);
            return reference;
        }

        // POST api/<ReferenceController>
        [HttpPost]
        public void Post([FromBody] Reference value)
        {
            referenceRepository.Insert(value);
        }

        // PUT api/<ReferenceController>/5
        [HttpPut("{id}")]
        public void Put(int id, Reference reference)
        {
            referenceRepository.Update(reference,id);
        }

        // DELETE api/<ReferenceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
