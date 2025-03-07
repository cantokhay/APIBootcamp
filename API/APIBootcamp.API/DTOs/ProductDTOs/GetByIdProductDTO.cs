namespace APIBootcamp.API.DTOs.ProductDTOs
{
    public class GetByIdProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageURL { get; set; }
    }
}
