using Microsoft.AspNetCore.Mvc;

namespace AppLayerMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.User = HttpContext.Session.GetString("UserName");
            return View();
        }
    }
}
