using Microsoft.AspNetCore.Mvc;
using Mongo.Dtos.ProductDto;
using Mongo.Service.CategoryServices;
using Mongo.Service.ProductServices;

namespace Mongo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            await _productService.CreateProductAsync(dto);
            return RedirectToAction("ProductList");
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var values = await _productService.GetProductByIdAsync(id);
            var model = new UpdateProductDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Price = values.Price,
                OldPrice = values.OldPrice,
                ImageUrl = values.ImageUrl,
                TotalTime = values.TotalTime,
                CategoryName = values.CategoryName
            };
            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            await _productService.UpdateProductAsync(dto);
            return RedirectToAction("ProductList");
        }
    }
}