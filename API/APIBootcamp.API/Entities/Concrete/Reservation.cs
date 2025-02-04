using APIBootcamp.API.Entities.Abstract;
using APIBootcamp.API.Entities.Enum;

namespace APIBootcamp.API.Entities.Concrete
{
    public class Reservation : IGenericEntity<Reservation>
    {
        public int Id { get; set; }
        public string ReservationFullName { get; set; }
        public string ReservationEmail{ get; set; }
        public string ReservationPhoneNumber { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationHour { get; set; }
        public int ReservationPeopleCount { get; set; }
        public string ReservationMessage { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public DataStatus DataStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
