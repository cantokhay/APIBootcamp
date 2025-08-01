using APIBootcamp.API.Context;
using APIBootcamp.API.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly APIBootcampContext _context;

        public ServicesController(APIBootcampContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var entitiesList = _context.Services.Where(x => x.DataStatus != Entities.Enum.DataStatus.Deleted).ToList();
            return Ok(entitiesList);
        }

        [HttpPost]
        public IActionResult CreateService(Service entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = Entities.Enum.DataStatus.Created;
            entity.ModifiedDate = null;
            entity.DeletedDate = null;
            _context.Services.Add(entity);
            _context.SaveChanges();
            return Ok("Created Succesfully!");
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var entityToDelete = _context.Services.Find(id);
            entityToDelete.DataStatus = Entities.Enum.DataStatus.Deleted;
            entityToDelete.DeletedDate = DateTime.Now;
            entityToDelete.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok("Deleted Succesfully");
        }

        [HttpGet("GetServiceById")]
        public IActionResult GetServiceById(int id)
        {
            var entity = _context.Services.Find(id);
            return Ok(entity);
        }

        [HttpPut]
        public IActionResult UpdateService(Service entity)
        {
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;
            _context.Services.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }
    }
}
