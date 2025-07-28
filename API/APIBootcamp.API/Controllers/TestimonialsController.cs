using APIBootcamp.API.Context;
using APIBootcamp.API.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : Controller
    {
        private readonly APIBootcampContext _context;

        public TestimonialsController(APIBootcampContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var entitiesList = _context.Testimonials.ToList();
            return Ok(entitiesList);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = Entities.Enum.DataStatus.Created;
            entity.ModifiedDate = null;
            entity.DeletedDate = null;
            _context.Testimonials.Add(entity);
            _context.SaveChanges();
            return Ok("Created Succesfully!");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var entityToDelete = _context.Testimonials.Find(id);
            entityToDelete.DataStatus = Entities.Enum.DataStatus.Deleted;
            entityToDelete.DeletedDate = DateTime.Now;
            entityToDelete.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok("Deleted Succesfully");
        }

        [HttpGet("GetTestimonialById")]
        public IActionResult GetTestimonialById(int id)
        {
            var entity = _context.Testimonials.Find(id);
            return Ok(entity);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial entity)
        {
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;
            _context.Testimonials.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }
    }
}
