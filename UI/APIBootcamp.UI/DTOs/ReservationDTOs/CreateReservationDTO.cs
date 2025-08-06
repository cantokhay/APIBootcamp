namespace APIBootcamp.UI.DTOs.ReservationDTOs
{
    public class CreateReservationDTO
    {
        //public int Id { get; set; }
        public string ReservationFullName { get; set; }
        public string ReservationEmail { get; set; }
        public string ReservationPhoneNumber { get; set; }
        public string ReservationDate { get; set; }
        public string ReservationHour { get; set; }
        public int ReservationPeopleCount { get; set; }
        public string ReservationMessage { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DataStatus DataStatus { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        //public DateTime? DeletedDate { get; set; }
    }
    public enum ReservationStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3,
        Completed = 4
    }
}
