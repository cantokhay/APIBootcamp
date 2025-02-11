using APIBootcamp.API.Context;
using APIBootcamp.API.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly APIBootcampContext _context;

        public ChefsController(APIBootcampContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ChefList()
        {
            var entitiesList = _context.Chefs.ToList();
            return Ok(entitiesList);
        }

        [HttpPost]
        public IActionResult CreateChef(Chef entity)
        {
            _context.Chefs.Add(entity);
            _context.SaveChanges();
            return Ok("Chef created succesfully!");
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var entityToDelete = _context.Chefs.Find(id);
            _context.Chefs.Remove(entityToDelete);
            _context.SaveChanges();
            return Ok("Chef deleted succesfully!");
        }

        [HttpGet("GetChefById")]
        public IActionResult GetChefById(int id)
        {
            var entity = _context.Chefs.Find(id);
            return Ok(entity);
        }

        [HttpPut]
        public IActionResult UpdateChef(Chef entity)
        {
            _context.Chefs.Update(entity);
            _context.SaveChanges();
            return Ok("Chef updated succesfully!");
        }
    }
}
