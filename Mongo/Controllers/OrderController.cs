using Microsoft.AspNetCore.Mvc;
using Mongo.Dtos.OrderDto;
using Mongo.Service.OrderServices;

namespace Mongo.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> OrderList()
        {
            var values = await _orderService.GetAllOrderAsync();
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto _createOrderDto)
        {
            await _orderService.CreateOrderAsync(_createOrderDto);
            return RedirectToAction("OrderList");
        }

        public async Task<IActionResult> DeleteOrder(string id)
        {
            await _orderService.DeleteOrderAsync(id);
            return RedirectToAction("OrderList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateOrder(string id)
        {
            var value = await _orderService.GetOrderByIdAsync(id);
            return View(value);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDto _updateOrderDto)
        {
            await _orderService.UpdateOrderAsync(_updateOrderDto);
            return RedirectToAction("OrderList");
        }

        [HttpPost]
        public async Task<IActionResult> CreateFrontOrder(string CustomerName, string CustomerEmail, string Address, string Phone, string ProductInfo)
        {
            if (!string.IsNullOrEmpty(ProductInfo))
            {
                // ProductInfo format: "ProductName|UnitPrice"
                var parts = ProductInfo.Split('|');
                var productName = parts[0];
                decimal unitPrice = 0;
                if (parts.Length > 1) decimal.TryParse(parts[1], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out unitPrice);

                var dto = new CreateOrderDto
                {
                    CustomerName = CustomerName,
                    CustomerEmail = CustomerEmail,
                    Address = Address,
                    Phone = Phone,
                    ProductName = productName,
                    Quantity = 1,
                    UnitPrice = unitPrice
                };
                await _orderService.CreateOrderAsync(dto);
            }
            return RedirectToAction("Index", "Default");
        }
    }
}
