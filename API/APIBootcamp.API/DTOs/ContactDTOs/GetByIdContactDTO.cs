namespace APIBootcamp.API.DTOs.ContactDTOs
{
    public class GetByIdContactDTO
    {
        public int Id { get; set; }
        public string ContactMapLocation { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactOpenHours { get; set; }
    }
}
