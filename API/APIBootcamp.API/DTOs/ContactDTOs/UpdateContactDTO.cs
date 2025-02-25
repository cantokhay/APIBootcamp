namespace APIBootcamp.API.DTOs.ContactDTOs
{
    public class UpdateContactDTO
    {
        public int Id { get; set; }
        public string ContactMapLocation { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactOpenHours { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
