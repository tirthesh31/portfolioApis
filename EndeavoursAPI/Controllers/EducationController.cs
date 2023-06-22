using Endeavours.DAL;
using Endeavours.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EndeavoursAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        Education education = new Education();
        EducationRepository educationRepository = new EducationRepository();
        // GET: api/<EducationController>
        [HttpGet]
        public string Get()
        {
            return  "value1";
        }

        // GET api/<EducationController>/5
        [HttpGet("{id}")]
        public Education Get(int id)
        {
            education = educationRepository.GetByID(id);
            return education;
        }

        // POST api/<EducationController>
        [HttpPost]
        public void Post([FromBody] Education value)
        {
            educationRepository.Insert(value);
        }

        // PUT api/<EducationController>/5
        [HttpPut("{id}")]
        public void Put(int id, Education Ueducation)
        {
            educationRepository.Update(Ueducation,id);
        }

        // DELETE api/<EducationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
