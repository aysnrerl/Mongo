using Microsoft.AspNetCore.Mvc;

namespace Mongo.ViewComponents
{
    public class _DefaultStatisticComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
