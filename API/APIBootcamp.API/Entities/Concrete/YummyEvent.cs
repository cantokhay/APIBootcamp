using APIBootcamp.API.Entities.Abstract;
using APIBootcamp.API.Entities.Enum;

namespace APIBootcamp.API.Entities.Concrete
{
    public class YummyEvent : IGenericEntity<YummyEvent>
    {
        public int Id { get; set; }
        public string YummyEventTitle { get; set; }
        public string YummyEventDescription { get; set; }
        public string YummyEventImageURL { get; set; }
        public decimal YummyEventPrice { get; set; }
        public bool YummyEventStatus { get; set; }

        public DataStatus DataStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
