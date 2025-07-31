using APIBootcamp.API.Context;
using APIBootcamp.API.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly APIBootcampContext _context;

        public ImagesController(APIBootcampContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ImageList()
        {
            var entitiesList = _context.Images.ToList();
            return Ok(entitiesList);
        }

        [HttpPost]
        public IActionResult CreateImage(Image entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = Entities.Enum.DataStatus.Created;
            entity.ModifiedDate = null;
            entity.DeletedDate = null;
            _context.Images.Add(entity);
            _context.SaveChanges();
            return Ok("Created Succesfully!");
        }

        [HttpDelete]
        public IActionResult DeleteImage(int id)
        {
            var entityToDelete = _context.Images.Find(id);
            entityToDelete.DataStatus = Entities.Enum.DataStatus.Deleted;
            entityToDelete.DeletedDate = DateTime.Now;
            entityToDelete.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok("Deleted Succesfully");
        }

        [HttpGet("GetImageById")]
        public IActionResult GetImageById(int id)
        {
            var entity = _context.Images.Find(id);
            return Ok(entity);
        }

        [HttpPut]
        public IActionResult UpdateImage(Image entity)
        {
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;
            _context.Images.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }
    }
}
