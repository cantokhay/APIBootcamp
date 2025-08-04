using APIBootcamp.API.Context;
using APIBootcamp.API.DTOs.YummyEventDTOs;
using APIBootcamp.API.Entities.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YummyEventsController : ControllerBase
    {
        private readonly APIBootcampContext _context;
        private readonly IMapper _mapper;

        public YummyEventsController(APIBootcampContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult YummyEventList()
        {
            var entitiesList = _context.YummyEvents.Where(x => x.DataStatus != Entities.Enum.DataStatus.Deleted).ToList();
            return Ok(_mapper.Map<List<ResultYummyEventDTO>>(entitiesList));
        }

        [HttpPost]
        public IActionResult CreateYummyEvent(CreateYummyEventDTO createYummyEventDTO)
        {
            var entity = _mapper.Map<YummyEvent>(createYummyEventDTO);
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
            return Ok(_mapper.Map<ResultYummyEventDTO>(entity));
        }

        [HttpPut]
        public IActionResult UpdateYummyEvent(UpdateYummyEventDTO updateYummyEventDTO)
        {
            var entity = _mapper.Map<YummyEvent>(updateYummyEventDTO);
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;
            _context.YummyEvents.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }

        [HttpPut("ChangeEventStatusFromTrueToFalse")]
        public IActionResult ChangeEventStatusFromTrueToFalse(UpdateYummyEventDTO updateYummyEventDTO)
        {
            var entity = _mapper.Map<YummyEvent>(updateYummyEventDTO);
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;
            entity.YummyEventStatus = false;
            _context.YummyEvents.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }

        [HttpPut("ChangeEventStatusFromFalseToTrue")]
        public IActionResult ChangeEventStatusFromFalseToTrue(UpdateYummyEventDTO updateYummyEventDTO)
        {
            var entity = _mapper.Map<YummyEvent>(updateYummyEventDTO);
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;
            entity.YummyEventStatus = true;
            _context.YummyEvents.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }
    }
}
