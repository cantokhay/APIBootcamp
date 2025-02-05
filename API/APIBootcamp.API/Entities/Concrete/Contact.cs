using APIBootcamp.API.Entities.Abstract;
using APIBootcamp.API.Entities.Enum;

namespace APIBootcamp.API.Entities.Concrete
{
    public class Contact : IGenericEntity<Contact>
    {
        public int Id { get; set; }
        public string ContactMapLocation { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactOpenHours { get; set; }
        public DataStatus DataStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
