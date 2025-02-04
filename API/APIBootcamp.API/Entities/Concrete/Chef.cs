using APIBootcamp.API.Entities.Abstract;
using APIBootcamp.API.Entities.Enum;

namespace APIBootcamp.API.Entities.Concrete
{
    public class Chef : IGenericEntity<Chef>
    {
        public int Id { get; set; }
        public string ChefFullName { get; set; }
        public string ChefTitle { get; set; }
        public string ChefComment { get; set; }
        public string ChefImageURL { get; set; }
        public DataStatus DataStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
