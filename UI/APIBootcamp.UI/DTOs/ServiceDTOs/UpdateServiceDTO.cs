namespace APIBootcamp.UI.DTOs.ServiceDTOs
{
    public class UpdateServiceDTO
    {
        public int Id { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceIconURL { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
