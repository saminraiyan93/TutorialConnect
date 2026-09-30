using Microsoft.AspNetCore.Mvc;

namespace AppLayerMVC.Controllers
{
    public class MainController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
