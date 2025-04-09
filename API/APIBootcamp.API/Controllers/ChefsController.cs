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
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = Entities.Enum.DataStatus.Created;
            entity.ModifiedDate = null;
            entity.DeletedDate = null;
            _context.Chefs.Add(entity);
            _context.SaveChanges();
            return Ok("Created Succesfully!");
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var entityToDelete = _context.Chefs.Find(id);
            entityToDelete.DataStatus = Entities.Enum.DataStatus.Deleted;
            entityToDelete.DeletedDate = DateTime.Now;
            entityToDelete.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok("Deleted Succesfully");
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
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;
            _context.Chefs.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }
    }
}
