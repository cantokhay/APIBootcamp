using APIBootcamp.API.Entities.Enum;

namespace APIBootcamp.API.DTOs.ReservationDTOs
{
    public class UpdateReservationDTO
    {
        public int Id { get; set; }
        public string ReservationFullName { get; set; }
        public string ReservationEmail { get; set; }
        public string ReservationPhoneNumber { get; set; }
        public DateOnly ReservationDate { get; set; }
        public string ReservationHour { get; set; }
        public int ReservationPeopleCount { get; set; }
        public string ReservationMessage { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
