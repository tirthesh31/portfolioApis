using Endeavours.DAL;
using Endeavours.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EndeavoursAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        TestimonialRepository testimonialRepository = new TestimonialRepository();
        Testimonial testimonial = new Testimonial();
        // GET: api/<TestimonialController>
        [HttpGet]
        public string Get()
        {
            return  "value2" ;
        }

        // GET api/<TestimonialController>/5
        [HttpGet("{id}")]
        public Testimonial Get(int id)
        {
            testimonial = testimonialRepository.GetByID(id);
            return testimonial;
        }

        // POST api/<TestimonialController>
        [HttpPost]
        public void Post([FromBody] Testimonial value)
        {
            testimonialRepository.Insert(value);
        }

        // PUT api/<TestimonialController>/5
        [HttpPut("{id}")]
        public void Put(int id, Testimonial testimonial)
        {
            testimonialRepository.Update(testimonial,id);
        }

        // DELETE api/<TestimonialController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
