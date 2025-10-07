namespace APIBootcamp.API.DTOs.ReservationDTOs
{
    public class ChartReservationDTO
    {
        public string Month { get; set; }
        public int Approved { get; set; }
        public int Cancelled { get; set; }
        public int Pending { get; set; }
    }
}
