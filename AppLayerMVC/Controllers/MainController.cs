using Microsoft.AspNetCore.Mvc;

namespace AppLayerMVC.Controllers
{
    public class MainController : Controller
    {
        public IActionResult HomePage()
        {
            // Get UserId from Session
            var userId = HttpContext.Session.GetString("UserId");

            // check if user logged in or not
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            // Get other session info's
            var userName = HttpContext.Session.GetString("UserName");
            var Email = HttpContext.Session.GetString("Email");
            var Role = HttpContext.Session.GetString("Role");

            ViewBag.userName = userName;
            ViewBag.userEmail = Email;
            ViewBag.userRole = Role;

            return View();
        }
    }
}
