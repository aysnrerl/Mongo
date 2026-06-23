using Microsoft.AspNetCore.Mvc;
using Mongo.Service.ProductServices;
using Mongo.Service.OrderServices;
using Mongo.Service.SubscribeServices;
using Mongo.Service.TestimonialServices; // Müşteri yorumları servisini ekledik

namespace Mongo.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly ISubscribeService _subscribeService;
        private readonly ITestimonialService _testimonialService; // Yeni enjeksiyon

        public AdminController(
            IProductService productService,
            IOrderService orderService,
            ISubscribeService subscribeService,
            ITestimonialService testimonialService)
        {
            _productService = productService;
            _orderService = orderService;
            _subscribeService = subscribeService;
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> Index()
        {
            // Veri tabanındaki tüm ilgili koleksiyonları asenkron olarak tetikliyoruz
            var products = await _productService.GetAllProductAsync();
            var orders = await _orderService.GetAllOrderAsync();
            var subscribes = await _subscribeService.GetAllSubscribeAsync();
            var testimonials = await _testimonialService.GetAllTestimonialAsync(); // Veriyi çektik

            // ViewBag paketlerimizi dolduruyoruz
            ViewBag.TotalProductCount = products != null ? products.Count : 0;
            ViewBag.TotalOrderCount = orders != null ? orders.Count : 0;
            ViewBag.TotalSubscribeCount = subscribes != null ? subscribes.Count : 0;
            ViewBag.TotalTestimonialCount = testimonials != null ? testimonials.Count : 0; // Yorum sayısı

            // Ciro hesaplama
            decimal totalRevenue = orders != null ? orders.Sum(x => x.TotalPrice) : 0;
            ViewBag.TotalRevenue = totalRevenue.ToString("C2");

            // Hem siparişleri hem de yorumları arayüze gönderebilmek için en temiz yol:
            // Siparişleri ana model olarak gönderip, yorumları ViewBag üzerinden taşımaktır.
            ViewBag.LatestTestimonials = testimonials;

            return View(orders);
        }
    }
}