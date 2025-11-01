using Microsoft.AspNetCore.Mvc;
using EcommerceStore.Models;
using EcommerceStore.Services;

namespace EcommerceStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController()
        {
            _productService = new ProductService();
        }

        public IActionResult Index()
        {
            var featuredProducts = _productService.GetFeaturedProducts();
            var categories = _productService.GetCategories();
            
            ViewBag.Categories = categories;
            return View(featuredProducts);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
