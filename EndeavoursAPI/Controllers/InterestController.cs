using Endeavours.DAL;
using Endeavours.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EndeavoursAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        InterestRepository interestRepository = new InterestRepository();
        Interest interest = new Interest();
        // GET: api/<InterestController>
        [HttpGet]
        public string Get()
        {
            return  "value2" ;
        }

        // GET api/<InterestController>/5
        [HttpGet("{id}")]
        public Interest Get(int id)
        {
            interest = interestRepository.GetByID(id);
            return interest;
        }

        // POST api/<InterestController>
        [HttpPost]
        public void Post([FromBody] Interest value)
        {
            interestRepository.Insert(value);
        }

        // PUT api/<InterestController>/5
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Interest value)
        {
            interestRepository.Update(value,id);
        }

        // DELETE api/<InterestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
