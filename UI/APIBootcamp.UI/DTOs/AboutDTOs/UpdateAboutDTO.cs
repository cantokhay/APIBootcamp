namespace APIBootcamp.UI.DTOs.AboutDTOs
{
    public class UpdateAboutDTO
    {
        public int Id { get; set; }
        public string AboutTitle { get; set; }
        public string AboutImageURL { get; set; }
        public string AboutVideoCoverImageURL { get; set; }
        public string AboutVideoURL { get; set; }
        public string AboutDescription { get; set; }
        public string AboutReservationPhoneNUmber { get; set; }
        //public DataStatus DataStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        //public DateTime? DeletedDate { get; set; }
    }
}
