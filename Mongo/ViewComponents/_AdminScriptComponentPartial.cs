using Microsoft.AspNetCore.Mvc;

namespace Mongo.ViewComponents
{
    public class _AdminScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
