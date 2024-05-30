namespace ConsumeWebApi.Models
{
    public class Product
    {
        public string ProductId { get; set; } = null!;
        public string? ProductName { get; set; }
        public string? ProductimageUrl { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
    }
}
