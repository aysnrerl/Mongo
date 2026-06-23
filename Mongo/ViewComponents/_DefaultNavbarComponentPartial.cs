using Microsoft.AspNetCore.Mvc;

namespace Mongo.ViewComponents
{
    public class _DefaultNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
