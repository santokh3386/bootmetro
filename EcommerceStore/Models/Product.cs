namespace EcommerceStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsOnSale { get; set; }
        public DateTime? SaleEndDate { get; set; }
        public int ViewCount { get; set; }
        public int PurchaseCount { get; set; }
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public string[] Features { get; set; } = Array.Empty<string>();
    }
}
