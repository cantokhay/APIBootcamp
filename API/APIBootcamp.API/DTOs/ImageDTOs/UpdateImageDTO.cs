namespace APIBootcamp.API.DTOs.ImageDTOs
{
    public class UpdateImageDTO
    {
        public int Id { get; set; }
        public string ImageAlt { get; set; }
        public string ImageURL { get; set; }
        public DateTime CreatedDate { get; set; }
        //public DataStatus DataStatus { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        //public DateTime? DeletedDate { get; set; }
    }
}
