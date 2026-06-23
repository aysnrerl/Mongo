using Microsoft.AspNetCore.Mvc;

namespace Mongo.ViewComponents
{
    public class _AdminFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
