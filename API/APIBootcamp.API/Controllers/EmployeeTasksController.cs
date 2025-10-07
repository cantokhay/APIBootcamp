using APIBootcamp.API.Context;
using APIBootcamp.API.DTOs.EmployeeTaskDTO;
using APIBootcamp.API.Entities.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTasksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly APIBootcampContext _context;

        public EmployeeTasksController(IMapper mapper, APIBootcampContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult EmployeeTaskList()
        {
            var entitiesList = _context.EmployeeTasks
                .Where(x => x.DataStatus != Entities.Enum.DataStatus.Deleted)
                .ToList();

            return Ok(_mapper.Map<List<ResultEmployeeTaskDTO>>(entitiesList));
        }

        [HttpPost]
        public IActionResult CreateEmployeeTask(CreateEmployeeTaskDTO createEmployeeTaskDTO)
        {
            var entity = _mapper.Map<EmployeeTask>(createEmployeeTaskDTO);
            entity.EmployeeTaskStatus = Entities.Enum.EmployeeTaskStatus.NotStarted;
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = Entities.Enum.DataStatus.Created;
            entity.ModifiedDate = null;
            entity.DeletedDate = null;

            _context.EmployeeTasks.Add(entity);
            _context.SaveChanges();

            return Ok("Created Successfully!");
        }

        [HttpPut]
        public IActionResult UpdateEmployeeTask(UpdateEmployeeTaskDTO updateEmployeeTaskDTO)
        {
            var entity = _mapper.Map<EmployeeTask>(updateEmployeeTaskDTO);
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = Entities.Enum.DataStatus.Modified;

            _context.EmployeeTasks.Update(entity);
            _context.SaveChanges();

            return Ok("Updated Successfully!");
        }

        [HttpDelete]
        public IActionResult DeleteEmployeeTask(int id)
        {
            var entityToDelete = _context.EmployeeTasks.Find(id);
            if (entityToDelete == null)
                return NotFound("Employee Task not found!");

            entityToDelete.DataStatus = Entities.Enum.DataStatus.Deleted;
            entityToDelete.DeletedDate = DateTime.Now;
            entityToDelete.ModifiedDate = DateTime.Now;

            _context.SaveChanges();
            return Ok("Deleted Successfully!");
        }

        [HttpGet("GetEmployeeTaskById")]
        public IActionResult GetEmployeeTaskById(int id)
        {
            var entity = _context.EmployeeTasks.Find(id);
            if (entity == null)
                return NotFound("Employee Task not found!");

            return Ok(_mapper.Map<ResultEmployeeTaskDTO>(entity));
        }

        [HttpGet("GetEmployeeTaskByStatus")]
        public IActionResult GetEmployeeTaskByStatus(Entities.Enum.EmployeeTaskStatus status)
        {
            var entities = _context.EmployeeTasks
                .Where(x => x.EmployeeTaskStatus == status)
                .ToList();

            return Ok(_mapper.Map<List<ResultEmployeeTaskDTO>>(entities));
        }

        [HttpPut("ChangeStatus")]
        public IActionResult ChangeStatus(int id, Entities.Enum.EmployeeTaskStatus newStatus)
        {
            var entity = _context.EmployeeTasks.Find(id);
            if (entity == null)
                return NotFound("Employee Task not found!");

            entity.EmployeeTaskStatus = newStatus;
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;

            _context.EmployeeTasks.Update(entity);
            _context.SaveChanges();

            return Ok("Status Updated Successfully!");
        }
    }
}
