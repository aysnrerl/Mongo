using Microsoft.AspNetCore.Mvc;

namespace Mongo.ViewComponents
{
    public class _AdminNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
