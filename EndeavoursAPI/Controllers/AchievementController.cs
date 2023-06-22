using Endeavours.DAL;
using Endeavours.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EndeavoursAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementController : ControllerBase
    {
        AchievementRepository achievementRepository = new AchievementRepository();
        Achievement achievement = new Achievement();
        // GET: api/<AchievementController>
        [HttpGet]
        public string Get()
        {
            return  "value2";
        }

        // GET api/<AchievementController>/5
        [HttpGet("{id}")]
        public Achievement Get(int id)
        {
            achievement = achievementRepository.GetByID(id);
            return achievement;
        }

        // POST api/<AchievementController>
        [HttpPost]
        public void Post([FromBody] Achievement value)
        {
            achievementRepository.Insert(value);    
        }

        // PUT api/<AchievementController>/5
        [HttpPut("{id}")]
        public void Put(int id, Achievement achievment)
        {
            achievementRepository.Update(achievement,id);
        }

        // DELETE api/<AchievementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
