using Microsoft.AspNetCore.Mvc;
using Mongo.Service.AboutSection2Services;

namespace Mongo.ViewComponents
{
    public class _DefaultAboutSection2ComponentPartial : ViewComponent
    {
        private readonly IAboutSection2Service _aboutSection2Service;

        public _DefaultAboutSection2ComponentPartial(IAboutSection2Service aboutSection2Service)
        {
            _aboutSection2Service = aboutSection2Service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutSection2Service.GetAllAboutSection2Async();
            return View(values);
        }
    }
}
