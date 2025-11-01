namespace EcommerceStore.Models.ViewModels
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; } = new Product();
        public List<Product> RelatedProducts { get; set; } = new List<Product>();
        public int StockUrgencyThreshold { get; set; } = 10;
        public bool ShowCountdown { get; set; }
        public DateTime? CountdownEndDate { get; set; }
    }
}
