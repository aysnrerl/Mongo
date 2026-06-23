using Microsoft.AspNetCore.Mvc;
using Mongo.Service.ProductServices;

namespace Mongo.ViewComponents
{
    public class _DefaultProductComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultProductComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }
    }
}
