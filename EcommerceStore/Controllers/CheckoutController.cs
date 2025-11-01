using Microsoft.AspNetCore.Mvc;
using EcommerceStore.Models;
using Newtonsoft.Json;

namespace EcommerceStore.Controllers
{
    public class CheckoutController : Controller
    {
        private const string CartSessionKey = "ShoppingCart";

        public IActionResult Index()
        {
            var cart = GetCart();
            if (!cart.Any())
            {
                return RedirectToAction("Index", "Products");
            }

            return View(cart);
        }

        [HttpPost]
        public IActionResult ProcessOrder(Customer customer)
        {
            var cart = GetCart();
            if (!cart.Any())
            {
                return RedirectToAction("Index", "Products");
            }

            // In a real application, you would save the order to a database
            var order = new Order
            {
                OrderNumber = $"ORD-{DateTime.Now:yyyyMMddHHmmss}",
                OrderDate = DateTime.Now,
                CustomerName = customer.Name,
                CustomerEmail = customer.Email,
                ShippingAddress = $"{customer.Address}, {customer.City}, {customer.Country}",
                TotalAmount = cart.Sum(c => c.Total),
                Status = "Processing"
            };

            // Clear cart
            HttpContext.Session.Remove(CartSessionKey);

            TempData["OrderNumber"] = order.OrderNumber;
            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            var orderNumber = TempData["OrderNumber"] as string;
            if (string.IsNullOrEmpty(orderNumber))
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.OrderNumber = orderNumber;
            return View();
        }

        private List<CartItem> GetCart()
        {
            var cartJson = HttpContext.Session.GetString(CartSessionKey);
            if (string.IsNullOrEmpty(cartJson))
            {
                return new List<CartItem>();
            }
            return JsonConvert.DeserializeObject<List<CartItem>>(cartJson) ?? new List<CartItem>();
        }
    }
}
