using APIBootcamp.API.Entities.Enum;

namespace APIBootcamp.API.Entities.Abstract
{
    public interface IGenericEntity<T> where T : class
    {
        public int Id { get; set; }
        public DataStatus DataStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
