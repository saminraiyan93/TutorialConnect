using Microsoft.AspNetCore.Mvc;
using AppLayerMVC.Models.Account;
namespace AppLayerAPI.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginModel());              // value = @Model.UserName; the View expects a Model; so initially we send an empty object as Model Binding
        }

        [HttpPost]
        public IActionResult Login(LoginModel obj)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("HomePage", "Main");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View(new RegistrationModel());   // value = @Model.UserName ,  value = @Model.Email ... initially Model can't be null. but UserName = null, Email = null can be true, thats why create an empty object
        }

        [HttpPost]
        public IActionResult Registration(RegistrationModel obj)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(obj);
        }
    }
}
