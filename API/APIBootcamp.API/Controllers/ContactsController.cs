using APIBootcamp.API.Context;
using APIBootcamp.API.DTOs.ContactDTOs;
using APIBootcamp.API.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly APIBootcampContext _context;

        public ContactsController(APIBootcampContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            return Ok(_context.Contacts.ToList());
        }

        [HttpPost]
        public IActionResult CreateContact([FromBody] CreateContactDTO createContactDTO)
        {
            var entity = new Contact
            {
                ContactMapLocation = createContactDTO.ContactMapLocation,
                ContactAddress = createContactDTO.ContactAddress,
                ContactPhoneNumber = createContactDTO.ContactPhoneNumber,
                ContactEmail = createContactDTO.ContactEmail,
                ContactOpenHours = createContactDTO.ContactOpenHours,
                CreatedDate = DateTime.Now,
                DataStatus = Entities.Enum.DataStatus.Created,
                ModifiedDate = null,
                DeletedDate = null
            };
            _context.Contacts.Add(entity);
            _context.SaveChanges();
            return Ok("Created Succesfully");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var entityToDelete = _context.Contacts.Find(id);
            entityToDelete.DataStatus = Entities.Enum.DataStatus.Deleted;
            entityToDelete.DeletedDate = DateTime.Now;
            entityToDelete.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok("Deleted Succesfully");
        }

        [HttpGet("GetContactById")]
        public IActionResult GetContactById(int id)
        {
            var entity = _context.Contacts.Find(id);
            return Ok(entity);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDTO updateContactDTO)
        {
            Contact entityToUpdate = new Contact();
            entityToUpdate.Id = updateContactDTO.Id;
            entityToUpdate.ContactEmail = updateContactDTO.ContactEmail;
            entityToUpdate.ContactAddress = updateContactDTO.ContactAddress;
            entityToUpdate.ContactMapLocation = updateContactDTO.ContactMapLocation;
            entityToUpdate.ContactOpenHours = updateContactDTO.ContactOpenHours;
            entityToUpdate.ContactPhoneNumber = updateContactDTO.ContactPhoneNumber;
            entityToUpdate.ModifiedDate = DateTime.Now;
            entityToUpdate.DataStatus = Entities.Enum.DataStatus.Modified;
            _context.Contacts.Update(entityToUpdate);
            _context.SaveChanges();
            return Ok("Updated Succesfully");
        }
    }
}
