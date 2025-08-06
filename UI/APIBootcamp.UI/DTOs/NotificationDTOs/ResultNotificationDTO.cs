namespace APIBootcamp.UI.DTOs.NotificationDTOs
{
    public class ResultNotificationDTO
    {
        public int Id { get; set; }
        public string NotificationDescription { get; set; }
        public string NotificationIconURL { get; set; }
        public bool NotificationIsRead { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
