using Microsoft.AspNetCore.Mvc;

namespace AppLayerMVC.Controllers
{
    public class StudentRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
