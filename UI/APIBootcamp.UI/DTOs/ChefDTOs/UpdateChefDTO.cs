namespace APIBootcamp.UI.DTOs.ChefDTOs
{
    public class UpdateChefDTO
    {
        public int Id { get; set; }
        public string ChefFullName { get; set; }
        public string ChefTitle { get; set; }
        public string ChefComment { get; set; }
        public string ChefImageURL { get; set; }
        //public DataStatus DataStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
