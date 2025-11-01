using Microsoft.AspNetCore.Mvc;
using EcommerceStore.Models;
using EcommerceStore.Models.ViewModels;
using EcommerceStore.Services;

namespace EcommerceStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController()
        {
            _productService = new ProductService();
        }

        public IActionResult Index(int? categoryId, string? search, string? sort)
        {
            var products = _productService.GetAllProducts();

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value).ToList();
            }

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => 
                    p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    p.Description.Contains(search, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            products = sort switch
            {
                "price_asc" => products.OrderBy(p => p.Price).ToList(),
                "price_desc" => products.OrderByDescending(p => p.Price).ToList(),
                "name" => products.OrderBy(p => p.Name).ToList(),
                "popular" => products.OrderByDescending(p => p.PurchaseCount).ToList(),
                _ => products.OrderByDescending(p => p.IsFeatured).ThenByDescending(p => p.Id).ToList()
            };

            ViewBag.Categories = _productService.GetCategories();
            ViewBag.CurrentCategory = categoryId;
            ViewBag.CurrentSearch = search;
            ViewBag.CurrentSort = sort;

            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductDetailViewModel
            {
                Product = product,
                RelatedProducts = _productService.GetRelatedProducts(product.CategoryId, product.Id),
                ShowCountdown = product.IsOnSale && product.SaleEndDate.HasValue,
                CountdownEndDate = product.SaleEndDate,
                StockUrgencyThreshold = 10
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            var products = _productService.SearchProducts(query);
            return Json(products);
        }
    }
}
