using EcommerceStore.Models;

namespace EcommerceStore.Services
{
    public class ProductService : IProductService
    {
        private static List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Electronics", Description = "Latest gadgets and electronics", IconClass = "bi-laptop" },
            new Category { Id = 2, Name = "Fashion", Description = "Trendy clothing and accessories", IconClass = "bi-bag" },
            new Category { Id = 3, Name = "Home & Living", Description = "Furniture and home decor", IconClass = "bi-house" },
            new Category { Id = 4, Name = "Sports", Description = "Sports equipment and gear", IconClass = "bi-trophy" },
            new Category { Id = 5, Name = "Books", Description = "Books and educational materials", IconClass = "bi-book" }
        };

        private static List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Premium Wireless Headphones",
                Description = "High-quality wireless headphones with noise cancellation and 30-hour battery life. Perfect for music lovers and professionals.",
                Price = 199.99M,
                OriginalPrice = 299.99M,
                ImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500",
                StockQuantity = 5,
                CategoryId = 1,
                IsFeatured = true,
                IsOnSale = true,
                SaleEndDate = DateTime.Now.AddDays(2),
                ViewCount = 1250,
                PurchaseCount = 89,
                Rating = 4.8,
                ReviewCount = 156,
                Images = new List<string> 
                { 
                    "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500",
                    "https://images.unsplash.com/photo-1484704849700-f032a568e944?w=500"
                },
                Features = new[] { "Active Noise Cancellation", "30-Hour Battery", "Bluetooth 5.0", "Premium Sound Quality" }
            },
            new Product
            {
                Id = 2,
                Name = "Smart Watch Pro",
                Description = "Advanced smartwatch with health tracking, GPS, and water resistance. Stay connected and healthy.",
                Price = 349.99M,
                OriginalPrice = 449.99M,
                ImageUrl = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=500",
                StockQuantity = 8,
                CategoryId = 1,
                IsFeatured = true,
                IsOnSale = true,
                SaleEndDate = DateTime.Now.AddHours(18),
                ViewCount = 2100,
                PurchaseCount = 145,
                Rating = 4.6,
                ReviewCount = 203,
                Images = new List<string> 
                { 
                    "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=500"
                },
                Features = new[] { "Heart Rate Monitor", "GPS Tracking", "Water Resistant", "7-Day Battery" }
            },
            new Product
            {
                Id = 3,
                Name = "Designer Leather Jacket",
                Description = "Premium leather jacket with modern design. Perfect for any occasion.",
                Price = 299.99M,
                OriginalPrice = 399.99M,
                ImageUrl = "https://images.unsplash.com/photo-1551028719-00167b16eac5?w=500",
                StockQuantity = 3,
                CategoryId = 2,
                IsFeatured = true,
                IsOnSale = true,
                SaleEndDate = DateTime.Now.AddDays(1),
                ViewCount = 890,
                PurchaseCount = 67,
                Rating = 4.9,
                ReviewCount = 89,
                Images = new List<string> 
                { 
                    "https://images.unsplash.com/photo-1551028719-00167b16eac5?w=500"
                },
                Features = new[] { "Genuine Leather", "Multiple Pockets", "Comfortable Fit", "Premium Quality" }
            },
            new Product
            {
                Id = 4,
                Name = "Modern Coffee Table",
                Description = "Elegant coffee table with storage space. Perfect centerpiece for your living room.",
                Price = 249.99M,
                OriginalPrice = 349.99M,
                ImageUrl = "https://images.unsplash.com/photo-1532372320572-cda25653a26d?w=500",
                StockQuantity = 12,
                CategoryId = 3,
                IsFeatured = false,
                IsOnSale = false,
                ViewCount = 456,
                PurchaseCount = 34,
                Rating = 4.5,
                ReviewCount = 45,
                Images = new List<string> 
                { 
                    "https://images.unsplash.com/photo-1532372320572-cda25653a26d?w=500"
                },
                Features = new[] { "Solid Wood", "Storage Space", "Easy Assembly", "Modern Design" }
            },
            new Product
            {
                Id = 5,
                Name = "Professional Running Shoes",
                Description = "High-performance running shoes with advanced cushioning technology.",
                Price = 129.99M,
                OriginalPrice = 179.99M,
                ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500",
                StockQuantity = 6,
                CategoryId = 4,
                IsFeatured = true,
                IsOnSale = true,
                SaleEndDate = DateTime.Now.AddHours(12),
                ViewCount = 1567,
                PurchaseCount = 234,
                Rating = 4.7,
                ReviewCount = 312,
                Images = new List<string> 
                { 
                    "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500"
                },
                Features = new[] { "Advanced Cushioning", "Breathable Material", "Lightweight", "Durable Sole" }
            },
            new Product
            {
                Id = 6,
                Name = "Bestseller Novel Collection",
                Description = "Collection of 5 bestselling novels from award-winning authors.",
                Price = 79.99M,
                OriginalPrice = 99.99M,
                ImageUrl = "https://images.unsplash.com/photo-1544947950-fa07a98d237f?w=500",
                StockQuantity = 15,
                CategoryId = 5,
                IsFeatured = false,
                IsOnSale = false,
                ViewCount = 678,
                PurchaseCount = 123,
                Rating = 4.8,
                ReviewCount = 167,
                Images = new List<string> 
                { 
                    "https://images.unsplash.com/photo-1544947950-fa07a98d237f?w=500"
                },
                Features = new[] { "5 Books Included", "Hardcover Edition", "Award Winners", "Gift Box Packaging" }
            },
            new Product
            {
                Id = 7,
                Name = "4K Ultra HD Camera",
                Description = "Professional 4K camera with advanced features for photography enthusiasts.",
                Price = 899.99M,
                OriginalPrice = 1199.99M,
                ImageUrl = "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?w=500",
                StockQuantity = 4,
                CategoryId = 1,
                IsFeatured = true,
                IsOnSale = true,
                SaleEndDate = DateTime.Now.AddDays(3),
                ViewCount = 2345,
                PurchaseCount = 56,
                Rating = 4.9,
                ReviewCount = 78,
                Images = new List<string> 
                { 
                    "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?w=500"
                },
                Features = new[] { "4K Video Recording", "24MP Sensor", "WiFi Connectivity", "Professional Lens" }
            },
            new Product
            {
                Id = 8,
                Name = "Luxury Handbag",
                Description = "Designer handbag made from premium materials. Elegant and spacious.",
                Price = 449.99M,
                OriginalPrice = 599.99M,
                ImageUrl = "https://images.unsplash.com/photo-1584917865442-de89df76afd3?w=500",
                StockQuantity = 7,
                CategoryId = 2,
                IsFeatured = true,
                IsOnSale = true,
                SaleEndDate = DateTime.Now.AddHours(36),
                ViewCount = 1890,
                PurchaseCount = 92,
                Rating = 4.7,
                ReviewCount = 134,
                Images = new List<string> 
                { 
                    "https://images.unsplash.com/photo-1584917865442-de89df76afd3?w=500"
                },
                Features = new[] { "Genuine Leather", "Multiple Compartments", "Adjustable Strap", "Designer Brand" }
            }
        };

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetFeaturedProducts()
        {
            return _products.Where(p => p.IsFeatured).Take(6).ToList();
        }

        public List<Product> GetRelatedProducts(int categoryId, int excludeProductId)
        {
            return _products
                .Where(p => p.CategoryId == categoryId && p.Id != excludeProductId)
                .Take(4)
                .ToList();
        }

        public List<Category> GetCategories()
        {
            return _categories;
        }

        public List<Product> SearchProducts(string query)
        {
            if (string.IsNullOrEmpty(query))
                return new List<Product>();

            return _products
                .Where(p => p.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                           p.Description.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
