using APIBootcamp.API.Context;
using APIBootcamp.API.DTOs.CategoryDTOs;
using APIBootcamp.API.DTOs.FeatureDTOs;
using APIBootcamp.API.Entities.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly APIBootcampContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(APIBootcampContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var entitiesList = _context.Categories.Where(x => x.DataStatus != Entities.Enum.DataStatus.Deleted).ToList();
            return Ok(_mapper.Map<List<ResultCategoryDTO>>(entitiesList));
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            //entity.CreatedDate = DateTime.Now;
            //entity.DataStatus = Entities.Enum.DataStatus.Created;
            //entity.ModifiedDate = null;
            //entity.DeletedDate = null;
            //_context.Categories.Add(entity);
            //_context.SaveChanges();
            //return Ok("Created Succesfully!");
            var entity = _mapper.Map<Category>(createCategoryDTO);
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = Entities.Enum.DataStatus.Created;
            entity.ModifiedDate = null;
            entity.DeletedDate = null;
            _context.Categories.Add(entity);
            _context.SaveChanges();
            return Ok("Created Succesfully!");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var entityToDelete = _context.Categories.Find(id);
            entityToDelete.DataStatus = Entities.Enum.DataStatus.Deleted;
            entityToDelete.DeletedDate = DateTime.Now;
            entityToDelete.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok("Deleted Succesfully");
        }

        [HttpGet("GetCategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            var entity = _context.Categories.Find(id);
            return Ok(_mapper.Map<ResultCategoryDTO>(entity));
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            var entity = _mapper.Map<Category>(updateCategoryDTO);
            entity.ModifiedDate = DateTime.Now;
            entity.DeletedDate = null;
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            _context.Categories.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully");
        }
    }
}
