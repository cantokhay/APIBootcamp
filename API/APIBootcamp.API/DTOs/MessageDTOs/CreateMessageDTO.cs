using APIBootcamp.API.Entities.Enum;

namespace APIBootcamp.API.DTOs.MessageDTOs
{
    public class CreateMessageDTO
    {
        public string MessageFullName { get; set; }
        public string MessageEmail { get; set; }
        public string MessageSubject { get; set; }
        public string? MessageType { get; set; }
        public string MessageDetails { get; set; }
        public DateTime SentDate { get; set; }
    }
}
