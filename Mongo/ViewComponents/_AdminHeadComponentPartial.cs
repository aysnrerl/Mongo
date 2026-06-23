using Microsoft.AspNetCore.Mvc;

namespace Mongo.ViewComponents
{
    public class _AdminHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
