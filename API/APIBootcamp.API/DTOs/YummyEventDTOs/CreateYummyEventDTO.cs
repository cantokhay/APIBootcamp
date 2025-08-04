namespace APIBootcamp.API.DTOs.YummyEventDTOs
{
    public class CreateYummyEventDTO
    {
        public string YummyEventTitle { get; set; }
        public string YummyEventDescription { get; set; }
        public string YummyEventImageURL { get; set; }
        public decimal YummyEventPrice { get; set; }
        public bool YummyEventStatus { get; set; }
    }
}
