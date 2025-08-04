namespace APIBootcamp.UI.DTOs.TestimonialDTOs
{
    public class UpdateTestimonialDTO
    {
        public int Id { get; set; }
        public string TestimonialFullName { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialComment { get; set; }
        public string TestimonialImageURL { get; set; }
        //public DataStatus DataStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
