using Endeavours.DAL;
using Endeavours.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EndeavoursAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperienceController : ControllerBase
    {
        WorkExperience workExperience = new WorkExperience();
        WorkExperienceRepository workExperienceRepository = new WorkExperienceRepository();
        // GET: api/<WorkExperienceController>
        [HttpGet]
        public string Get()
        {
            return  "value1";
        }

        // GET api/<WorkExperienceController>/5
        [HttpGet("{id}")]
        public WorkExperience Get(int id)
        {            
            workExperience = workExperienceRepository.GetByID(id);
            return workExperience;
        }

        // POST api/<WorkExperienceController>
        [HttpPost]
        public void Post([FromBody] WorkExperience value)
        {
            workExperienceRepository.Insert(value);
        }

        // PUT api/<WorkExperienceController>/5
        [HttpPut("{id}")]
        public void Put(int id, WorkExperience data)
        {
            workExperienceRepository.Update(data, id);
        }

        // DELETE api/<WorkExperienceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
