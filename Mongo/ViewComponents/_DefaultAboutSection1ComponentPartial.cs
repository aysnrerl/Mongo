using Microsoft.AspNetCore.Mvc;
using Mongo.Service.AboutSection1Services;

namespace Mongo.ViewComponents
{
    public class _DefaultAboutSection1ComponentPartial : ViewComponent
    {
        private readonly IAboutSection1Service _aboutSection1Service;

        public _DefaultAboutSection1ComponentPartial(IAboutSection1Service aboutSection1Service)
        {
            _aboutSection1Service = aboutSection1Service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutSection1Service.GetAllAboutSection1Async();
            return View(values);
        }
    }
}
