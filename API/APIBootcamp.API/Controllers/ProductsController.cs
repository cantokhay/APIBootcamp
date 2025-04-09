using APIBootcamp.API.Context;
using APIBootcamp.API.DTOs.ProductDTOs;
using APIBootcamp.API.Entities.Concrete;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly APIBootcampContext _context;
        private readonly IMapper _mapper;

        public ProductsController(IValidator<Product> validator, APIBootcampContext context, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpPost]
        public IActionResult CreateProduct(Product entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                entity.CreatedDate = DateTime.Now;
                entity.DataStatus = Entities.Enum.DataStatus.Created;
                entity.ModifiedDate = null;
                entity.DeletedDate = null;
                _context.Products.Add(entity);
                _context.SaveChanges();
                return Ok(new { message = "Ürün ekleme başarılı", data = entity }); //best of the best practice
            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var entityToDelete = _context.Products.Find(id);
            entityToDelete.DataStatus = Entities.Enum.DataStatus.Deleted;
            entityToDelete.DeletedDate = DateTime.Now;
            entityToDelete.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetProductById")]
        public IActionResult GetProductById(int id)
        {
            var entity = _context.Products.Find(id);
            return Ok(entity);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                entity.DataStatus = Entities.Enum.DataStatus.Modified;
                entity.ModifiedDate = DateTime.Now;
                _context.Products.Update(entity);
                _context.SaveChanges();
                return Ok(new { message = "Ürün güncelleme başarılı", data = entity });
            }
        }

        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDTO createProductDTO)
        {
            var entity = _mapper.Map<Product>(createProductDTO);
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Add(entity);
                _context.SaveChanges();
                return Ok(new { message = "Ürün ekleme başarılı", data = entity });
            }
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var valueList = _context.Products.Include(x => x.Category).ToList();
            return Ok(_mapper.Map<List<ResultProductWithCategoryDTO>>(valueList));
        }
    }
}
