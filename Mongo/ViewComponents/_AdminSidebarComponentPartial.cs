using Microsoft.AspNetCore.Mvc;

namespace Mongo.ViewComponents
{
    public class _AdminSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
