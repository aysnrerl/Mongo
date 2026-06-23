using Microsoft.AspNetCore.Mvc;

namespace Mongo.ViewComponents
{
    public class _DefaultHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
