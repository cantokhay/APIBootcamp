using APIBootcamp.API.Context;
using APIBootcamp.API.DTOs.MessageDTOs;
using APIBootcamp.API.Entities.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly APIBootcampContext _context;

        public MessagesController(IMapper mapper, APIBootcampContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var entitiesList = _context.Messages.Where(x => x.DataStatus != Entities.Enum.DataStatus.Deleted).ToList();
            return Ok(_mapper.Map<List<ResultMessageDTO>>(entitiesList));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDTO createMessageDTO)
        {
            var entity = _mapper.Map<Message>(createMessageDTO);
            entity.MessageStatus = Entities.Enum.MessageStatus.UnRead;
            entity.CreatedDate = DateTime.Now;
            entity.SentDate = DateTime.Now;
            entity.DataStatus = Entities.Enum.DataStatus.Created;
            entity.ModifiedDate = null;
            entity.DeletedDate = null;
            _context.Messages.Add(entity);
            _context.SaveChanges();
            return Ok("Created Succesfully!");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDTO updateMessageDTO)
        {
            var entity = _mapper.Map<Message>(updateMessageDTO);
            entity.CreatedDate = updateMessageDTO.CreatedDate;
            entity.ModifiedDate = DateTime.Now;
            entity.DeletedDate = null;
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            _context.Messages.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var entityToDelete = _context.Messages.Find(id);
            entityToDelete.DataStatus = Entities.Enum.DataStatus.Deleted;
            entityToDelete.DeletedDate = DateTime.Now;
            entityToDelete.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok("Deleted Succesfully");
        }

        [HttpGet("GetMessageById")]
        public IActionResult GetMessageById(int id)
        {
            var entity = _context.Messages.Find(id);
            return Ok(_mapper.Map<ResultMessageDTO>(entity));
        }

        [HttpGet("GetMessageByMessageStatusUnRead")]
        public IActionResult GetMessageByMessageStatusUnRead()
        {
            var entities = _context.Messages.Where(x => x.MessageStatus == Entities.Enum.MessageStatus.UnRead).ToList();
            return Ok(_mapper.Map<List<ResultMessageDTO>>(entities));
        }

        [HttpGet("GetMessageByMessageStatusRead")]
        public IActionResult GetMessageByMessageStatusRead()
        {
            var entities = _context.Messages.Where(x => x.MessageStatus == Entities.Enum.MessageStatus.Read).ToList();
            return Ok(_mapper.Map<List<ResultMessageDTO>>(entities));
        }

        [HttpPut("ChangeMessageStatusRead")]
        public IActionResult ChangeMessageStatusRead(UpdateMessageDTO updateMessageDTO)
        {
            var entity = _mapper.Map<Message>(updateMessageDTO);
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;
            entity.MessageStatus = Entities.Enum.MessageStatus.Read;
            _context.Messages.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }
        
        [HttpPut("ChangeMessageStatusUnRead")]
        public IActionResult ChangeMessageStatusUnRead(UpdateMessageDTO updateMessageDTO)
        {
            var entity = _mapper.Map<Message>(updateMessageDTO);
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;
            entity.MessageStatus = Entities.Enum.MessageStatus.UnRead;
            _context.Messages.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }
        
        [HttpPut("ChangeMessageStatusFailed")]
        public IActionResult ChangeMessageStatusFailed(UpdateMessageDTO updateMessageDTO)
        {
            var entity = _mapper.Map<Message>(updateMessageDTO);
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;
            entity.MessageStatus = Entities.Enum.MessageStatus.Failed;
            _context.Messages.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }
    }
}
