namespace APIBootcamp.API.DTOs.NotificationDTOs
{
    public class GetByIdNotificationDTO
    {
        public int Id { get; set; }
        public string NotificationDescription { get; set; }
        public string NotificationIconURL { get; set; }
        public bool NotificationIsRead { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
