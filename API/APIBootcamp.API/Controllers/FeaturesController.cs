using APIBootcamp.API.Context;
using APIBootcamp.API.DTOs.FeatureDTOs;
using APIBootcamp.API.Entities.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly APIBootcampContext _context;

        public FeaturesController(IMapper mapper, APIBootcampContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var entitiesList = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDTO>>(entitiesList));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            var entity = _mapper.Map<Feature>(createFeatureDTO);
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = Entities.Enum.DataStatus.Created;
            entity.ModifiedDate = null;
            entity.DeletedDate = null;
            _context.Features.Add(entity);
            _context.SaveChanges();
            return Ok("Created Succesfully!");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id) 
        {
            var entityToDelete = _context.Features.Find(id);
            entityToDelete.DataStatus = Entities.Enum.DataStatus.Deleted;
            entityToDelete.DeletedDate = DateTime.Now;
            entityToDelete.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok("Deleted Succesfully");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
        {
            var entity = _mapper.Map<Feature>(updateFeatureDTO);
            entity.ModifiedDate = DateTime.Now;
            entity.DeletedDate = null;
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            _context.Features.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully");
        }

        [HttpGet("GetFeatureById")]
        public IActionResult GetFeature(int id)
        {
            var entity = _context.Features.Find(id);
            return Ok(_mapper.Map<ResultFeatureDTO>(entity));
        }
    }
}
