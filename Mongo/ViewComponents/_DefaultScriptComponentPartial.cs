using Microsoft.AspNetCore.Mvc;

namespace Mongo.ViewComponents
{
    public class _DefaultScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
