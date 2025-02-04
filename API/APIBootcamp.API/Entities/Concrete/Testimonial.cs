using APIBootcamp.API.Entities.Abstract;
using APIBootcamp.API.Entities.Enum;

namespace APIBootcamp.API.Entities.Concrete
{
    public class Testimonial : IGenericEntity<Testimonial>
    {
        public int Id { get; set; }
        public string TestimonialFullName { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialComment{ get; set; }
        public string TestimonialImageURL{ get; set; }
        public DataStatus DataStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
