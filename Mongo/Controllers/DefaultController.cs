using Microsoft.AspNetCore.Mvc;

namespace Mongo.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
