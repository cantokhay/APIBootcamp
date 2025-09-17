namespace APIBootcamp.UI.DTOs.MessageDTOs
{
    public class ResultUnReadMessageDTO
    {
        public int Id { get; set; }
        public string MessageFullName { get; set; }
        public string MessageEmail { get; set; }
        public string MessageSubject { get; set; }
        public string? MessageType { get; set; }
        public string MessageDetails { get; set; }
        public DateTime SentDate { get; set; }
        public MessageStatus MessageStatus { get; set; }
        //public DataStatus DataStatus { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        //public DateTime? DeletedDate { get; set; }
    }
}
