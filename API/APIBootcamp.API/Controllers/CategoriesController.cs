﻿using APIBootcamp.API.Context;
using APIBootcamp.API.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly APIBootcampContext _context;

        public CategoriesController(APIBootcampContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var entitiesList = _context.Categories.ToList();
            return Ok(entitiesList);
        }

        [HttpPost]
        public IActionResult CreateCategory(Category entity)
        {
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
            return Ok(entity);
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category entity)
        {
            _context.Categories.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }
    }
}
