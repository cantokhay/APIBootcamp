using APIBootcamp.API.Context;
using APIBootcamp.API.DTOs.AboutDTOs;
using APIBootcamp.API.Entities.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly APIBootcampContext _context;

        public AboutsController(IMapper mapper, APIBootcampContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var entitiesList = _context.Abouts.Where(x => x.DataStatus != Entities.Enum.DataStatus.Deleted).ToList();
            return Ok(_mapper.Map<List<ResultAboutDTO>>(entitiesList));
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDTO createAboutDTO)
        {
            var entity = _mapper.Map<About>(createAboutDTO);
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = Entities.Enum.DataStatus.Created;
            entity.ModifiedDate = null;
            entity.DeletedDate = null;
            _context.Abouts.Add(entity);
            _context.SaveChanges();
            return Ok("Created Succesfully!");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var entityToDelete = _context.Abouts.Find(id);
            entityToDelete.DataStatus = Entities.Enum.DataStatus.Deleted;
            entityToDelete.DeletedDate = DateTime.Now;
            entityToDelete.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok("Deleted Succesfully");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            var entity = _mapper.Map<About>(updateAboutDTO);
            entity.ModifiedDate = DateTime.Now;
            entity.DeletedDate = null;
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            _context.Abouts.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully");
        }

        [HttpGet("GetAboutById")]
        public IActionResult GetAbout(int id)
        {
            var entity = _context.Abouts.Find(id);
            return Ok(_mapper.Map<ResultAboutDTO>(entity));
        }
    }
}
