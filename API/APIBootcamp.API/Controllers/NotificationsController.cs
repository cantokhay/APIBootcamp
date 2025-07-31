using APIBootcamp.API.Context;
using APIBootcamp.API.DTOs.NotificationDTOs;
using APIBootcamp.API.Entities.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly APIBootcampContext _context;

        public NotificationsController(IMapper mapper, APIBootcampContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var entitiesList = _context.Notifications.ToList();
            return Ok(_mapper.Map<List<ResultNotificationDTO>>(entitiesList));
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDTO createNotificationDTO)
        {
            var entity = _mapper.Map<Notification>(createNotificationDTO);
            entity.NotificationIsRead = false;
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = Entities.Enum.DataStatus.Created;
            entity.ModifiedDate = null;
            entity.DeletedDate = null;
            _context.Notifications.Add(entity);
            _context.SaveChanges();
            return Ok("Created Succesfully!");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDTO updateNotificationDTO)
        {
            var entity = _mapper.Map<Notification>(updateNotificationDTO);
            entity.CreatedDate = updateNotificationDTO.CreatedDate;
            entity.ModifiedDate = DateTime.Now;
            entity.DeletedDate = null;
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            _context.Notifications.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }

        [HttpDelete]
        public IActionResult DeleteNotification(int id)
        {
            var entityToDelete = _context.Notifications.Find(id);
            entityToDelete.DataStatus = Entities.Enum.DataStatus.Deleted;
            entityToDelete.DeletedDate = DateTime.Now;
            entityToDelete.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok("Deleted Succesfully");
        }

        [HttpGet("GetNotificationById")]
        public IActionResult GetNotificationById(int id)
        {
            var entity = _context.Notifications.Find(id);
            return Ok(_mapper.Map<ResultNotificationDTO>(entity));
        }

        [HttpGet("GetNotificationByNotificationStatusUnRead")]
        public IActionResult GetNotificationByNotificationStatusUnRead()
        {
            var entities = _context.Notifications.Where(x => x.NotificationIsRead == false).ToList();
            return Ok(_mapper.Map<List<ResultNotificationDTO>>(entities));
        }

        [HttpGet("GetNotificationByNotificationStatusRead")]
        public IActionResult GetNotificationByNotificationStatusRead()
        {
            var entities = _context.Notifications.Where(x => x.NotificationIsRead == true).ToList();
            return Ok(_mapper.Map<List<ResultNotificationDTO>>(entities));
        }

        [HttpPut("ChangeNotificationStatusReadById")]
        public IActionResult ChangeNotificationStatusReadById(int id)
        {
            var entity = _context.Notifications.Find(id);
            if (entity == null)
            {
                return NotFound("Notification not found");
            }
            entity.NotificationIsRead = true;
            entity.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok("Notification status changed to Read");
        }

        [HttpPut("ChangeNotificationStatusUnReadById")]
        public IActionResult ChangeNotificationStatusUnReadById(int id)
        {
            var entity = _context.Notifications.Find(id);
            if (entity == null)
            {
                return NotFound("Notification not found");
            }
            entity.NotificationIsRead = false;
            entity.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok("Notification status changed to UnRead");
        }
    }
}
