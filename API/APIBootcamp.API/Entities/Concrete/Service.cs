using APIBootcamp.API.Entities.Abstract;
using APIBootcamp.API.Entities.Enum;

namespace APIBootcamp.API.Entities.Concrete
{
    public class Service : IGenericEntity<Service>
    {
        public int Id { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription{ get; set; }
        public string ServiceIconURL{ get; set; }
        public DataStatus DataStatus { get; set; }  
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
