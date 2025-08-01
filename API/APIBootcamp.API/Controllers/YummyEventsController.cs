using APIBootcamp.API.Context;
using APIBootcamp.API.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YummyEventsController : ControllerBase
    {
        private readonly APIBootcampContext _context;

        public YummyEventsController(APIBootcampContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult YummyEventList()
        {
            var entitiesList = _context.YummyEvents.Where(x => x.DataStatus != Entities.Enum.DataStatus.Deleted).ToList();
            return Ok(entitiesList);
        }

        [HttpPost]
        public IActionResult CreateYummyEvent(YummyEvent entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = Entities.Enum.DataStatus.Created;
            entity.ModifiedDate = null;
            entity.DeletedDate = null;
            _context.YummyEvents.Add(entity);
            _context.SaveChanges();
            return Ok("Created Succesfully!");
        }

        [HttpDelete]
        public IActionResult DeleteYummyEvent(int id)
        {
            var entityToDelete = _context.YummyEvents.Find(id);
            entityToDelete.DataStatus = Entities.Enum.DataStatus.Deleted;
            entityToDelete.DeletedDate = DateTime.Now;
            entityToDelete.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok("Deleted Succesfully");
        }

        [HttpGet("GetYummyEventById")]
        public IActionResult GetYummyEventById(int id)
        {
            var entity = _context.YummyEvents.Find(id);
            return Ok(entity);
        }

        [HttpPut]
        public IActionResult UpdateYummyEvent(YummyEvent entity)
        {
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;
            _context.YummyEvents.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }
    }
}
