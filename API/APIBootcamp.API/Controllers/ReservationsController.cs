using APIBootcamp.API.Context;
using APIBootcamp.API.DTOs.ReservationDTOs;
using APIBootcamp.API.Entities.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly APIBootcampContext _context;
        private readonly IMapper _mapper;

        public ReservationsController(APIBootcampContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ReservationList()
        {
            var entitiesList = _context.Reservations.Where(x => x.DataStatus != Entities.Enum.DataStatus.Deleted).ToList();
            return Ok(_mapper.Map<List<ResultReservationDTO>>(entitiesList));
        }

        [HttpPost]
        public IActionResult CreateReservation(CreateReservationDTO createReservationDTO)
        {
            var entity = _mapper.Map<Reservation>(createReservationDTO);
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = Entities.Enum.DataStatus.Created;
            entity.ModifiedDate = null;
            entity.DeletedDate = null;
            _context.Reservations.Add(entity);
            _context.SaveChanges();
            return Ok("Created Succesfully!");
        }

        [HttpDelete]
        public IActionResult DeleteReservation(int id)
        {
            var entityToDelete = _context.Reservations.Find(id);
            entityToDelete.DataStatus = Entities.Enum.DataStatus.Deleted;
            entityToDelete.DeletedDate = DateTime.Now;
            entityToDelete.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok("Deleted Succesfully");
        }

        [HttpGet("GetReservationById")]
        public IActionResult GetReservationById(int id)
        {
            var entity = _context.Reservations.Find(id);
            return Ok(_mapper.Map<ResultReservationDTO>(entity));
        }

        [HttpPut]
        public IActionResult UpdateReservation(UpdateReservationDTO updateReservationDTO)
        {
            var entity = _mapper.Map<Reservation>(updateReservationDTO);
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;
            _context.Reservations.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }

        [HttpPut("ChangeReservationStatusToPending")]
        public IActionResult ChangeReservationStatusToPending(UpdateReservationDTO updateReservationDTO)
        {
            var entity = _mapper.Map<Reservation>(updateReservationDTO);
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;
            entity.ReservationStatus = Entities.Enum.ReservationStatus.Pending;
            _context.Reservations.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }

        [HttpPut("ChangeReservationStatusToApproved")]
        public IActionResult ChangeReservationStatusToApproved(UpdateReservationDTO updateReservationDTO)
        {
            var entity = _mapper.Map<Reservation>(updateReservationDTO);
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;
            entity.ReservationStatus = Entities.Enum.ReservationStatus.Approved;
            _context.Reservations.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }

        [HttpPut("ChangeReservationStatusToCompleted")]
        public IActionResult ChangeReservationStatusToCompleted(UpdateReservationDTO updateReservationDTO)
        {
            var entity = _mapper.Map<Reservation>(updateReservationDTO);
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;
            entity.ReservationStatus = Entities.Enum.ReservationStatus.Completed;
            _context.Reservations.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }

        [HttpPut("ChangeReservationStatusToRejected")]
        public IActionResult ChangeReservationStatusToRejected(UpdateReservationDTO updateReservationDTO)
        {
            var entity = _mapper.Map<Reservation>(updateReservationDTO);
            entity.DataStatus = Entities.Enum.DataStatus.Modified;
            entity.ModifiedDate = DateTime.Now;
            entity.ReservationStatus = Entities.Enum.ReservationStatus.Rejected;
            _context.Reservations.Update(entity);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }

        [HttpGet("GetTotalReservationCount")]
        public IActionResult GetTotalReservationCount()
        {
            var totalCount = _context.Reservations.Count(x => x.DataStatus != Entities.Enum.DataStatus.Deleted);
            return Ok(totalCount);
        }

        [HttpGet("GetTotalReservationCustomerCount")]
        public IActionResult GetTotalReservationCustomerCount()
        {
            var totalCustomerCount = _context.Reservations.Where(x => x.DataStatus != Entities.Enum.DataStatus.Deleted).Sum(x => x.ReservationPeopleCount);
            return Ok(totalCustomerCount);
        }

        [HttpGet("GetCountByReservationStatusPending")]
        public IActionResult GetCountByReservationStatusPending()
        {
            var totalCountByStatus = _context.Reservations.Count(x => x.DataStatus != Entities.Enum.DataStatus.Deleted && x.ReservationStatus == Entities.Enum.ReservationStatus.Pending);
            return Ok(totalCountByStatus);
        }

        [HttpGet("GetCountByReservationStatusApproved")]
        public IActionResult GetCountByReservationStatusApproved()
        {
            var totalCountByStatus = _context.Reservations.Count(x => x.DataStatus != Entities.Enum.DataStatus.Deleted && x.ReservationStatus == Entities.Enum.ReservationStatus.Approved);
            return Ok(totalCountByStatus);
        }

    }
}
