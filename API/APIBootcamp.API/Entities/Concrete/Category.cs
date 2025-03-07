using APIBootcamp.API.Entities.Abstract;
using APIBootcamp.API.Entities.Enum;

namespace APIBootcamp.API.Entities.Concrete
{
    public class Category : IGenericEntity<Category>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public DataStatus DataStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public List<Product> Products { get; set; }
    }
}
