using Endeavours.DAL;
using Endeavours.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EndeavoursAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        SkillRepository skillRepository = new SkillRepository();
        Skill skill = new Skill();
        // GET: api/<SkillController>
        [HttpGet]
        public string Get()
        {
            return  "value1";
        }

        // GET api/<SkillController>/5
        [HttpGet("{id}")]
        public Skill Get(int id)
        {
            skill = skillRepository.GetByID(id);
            return skill;
        }

        // POST api/<SkillController>
        [HttpPost]
        public void Post([FromBody] Skill value)
        {
            skillRepository.Insert(value);
        }

        // PUT api/<SkillController>/5
        [HttpPut("{id}")]
        public void Put(int id, Skill USkill)
        {
            skillRepository.Update(USkill,id);
        }

        // DELETE api/<SkillController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
