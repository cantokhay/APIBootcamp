using APIBootcamp.API.Entities.Enum;

namespace APIBootcamp.API.DTOs.MessageDTOs
{
    public class GetByIdMessageDTO
    {
        public int Id { get; set; }
        public string MessageFullName { get; set; }
        public string MessageEmail { get; set; }
        public string MessageSubject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime SentDate { get; set; }
        public MessageStatus MessageStatus { get; set; }
    }
}
