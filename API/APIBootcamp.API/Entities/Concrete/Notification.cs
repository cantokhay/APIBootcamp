using APIBootcamp.API.Entities.Abstract;
using APIBootcamp.API.Entities.Enum;

namespace APIBootcamp.API.Entities.Concrete
{
    public class Notification : IGenericEntity<Notification>
    {
        public int Id { get; set; }
        public string NotificationDescription { get; set; }
        public string NotificationIconURL { get; set; }
        public bool NotificationIsRead { get; set; }
        public DateTime CreatedDate { get; set; }
        public DataStatus DataStatus { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
