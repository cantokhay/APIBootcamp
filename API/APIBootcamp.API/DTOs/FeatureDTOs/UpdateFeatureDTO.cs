namespace APIBootcamp.API.DTOs.FeatureDTOs
{
    public class UpdateFeatureDTO
    {
        public int Id { get; set; }
        public string FeatureTitle { get; set; }
        public string FeatureSubTitle { get; set; }
        public string FeatureDescription { get; set; }
        public string FeatureVideoURL { get; set; }
        public string FeatureImageURL { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
