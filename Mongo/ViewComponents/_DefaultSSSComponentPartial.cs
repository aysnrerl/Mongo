using Microsoft.AspNetCore.Mvc;
using Mongo.Service.SSSServices; // SSS Servisinin bulunduğu namespace'i buraya ekle [cite: 50]

namespace Mongo.ViewComponents
{
    public class _DefaultSSSComponentPartial : ViewComponent
    {
        private readonly ISSSService _sssService;

        public _DefaultSSSComponentPartial(ISSSService sssService)
        {
            _sssService = sssService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _sssService.GetAllSSSAsync();
            return View(values);
        }
    }
}