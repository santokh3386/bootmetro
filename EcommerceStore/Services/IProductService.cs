using EcommerceStore.Models;

namespace EcommerceStore.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product? GetProductById(int id);
        List<Product> GetFeaturedProducts();
        List<Product> GetRelatedProducts(int categoryId, int excludeProductId);
        List<Category> GetCategories();
        List<Product> SearchProducts(string query);
    }
}
