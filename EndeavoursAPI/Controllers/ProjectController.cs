using Endeavours.DAL;
using Endeavours.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EndeavoursAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        ProjectRepository projectRepository = new ProjectRepository();
        Project project = new Project();
        // GET: api/<ProjectController>
        [HttpGet]
        public string Get()
        {
            return  "value2" ;
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public Project Get(int id)
        {
            project = projectRepository.GetByID(id);
            return project;
        }

        // POST api/<ProjectController>
        [HttpPost]
        public void Post([FromBody] Project value)
        {
            projectRepository.Insert(value);
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, Project Uproject)
        {
            projectRepository.Update(Uproject, id);
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
