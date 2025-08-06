using APIBootcamp.API.Context;
using APIBootcamp.API.DTOs.ImageDTOs;
using APIBootcamp.API.Entities.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly APIBootcampContext _context;

        public ImagesController(APIBootcampContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ImageList()
        {
            var entitiesList = _context.Images.Where(x => x.DataStatus != Entities.Enum.DataStatus.Deleted).ToList();
            return Ok(_mapper.Map<List<ResultImageDTO>>(entitiesList));
        }

        [HttpPost]
        public IActionResult CreateImage(CreateImageDTO createImageDTO)
        {
            var entity = _mapper.Map<Image>(createImageDTO);
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
            return Ok(_mapper.Map<ResultImageDTO>(entity));
        }

        [HttpPut]
        public IActionResult UpdateImage(UpdateImageDTO updateImageDTO)
        {
            var entity = _mapper.Map<Image>(updateImageDTO);
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;
            _context.Images.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }
    }
}
