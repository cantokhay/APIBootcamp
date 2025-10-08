using APIBootcamp.API.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly APIBootcampContext _context;

        public StatisticsController(APIBootcampContext context)
        {
            _context = context;
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var productCount = _context.Products.Count();
            return Ok(productCount);
        }

        [HttpGet("ReservationCount")]
        public IActionResult ReservationCount()
        {
            var reservationCount = _context.Reservations.Count();
            return Ok(reservationCount);
        }

        [HttpGet("TotalGuestCount")]
        public IActionResult TotalGuestCount()
        {
            var customerCount = _context.Reservations.Sum(x => x.ReservationPeopleCount);
            return Ok(customerCount);
        }

        [HttpGet("ChefCount")]
        public IActionResult ChefCount()
        {
            var chefCount = _context.Chefs.Count();
            return Ok(chefCount);
        }
    }
}
