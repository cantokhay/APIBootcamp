namespace APIBootcamp.UI.DTOs.ProductDTOs
{
    public class ResultProductWithCategoryDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageURL { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
