using Microsoft.AspNetCore.Mvc;
using AppLayerMVC.Models.Account;
namespace AppLayerAPI.Controllers;
using BLL.Service;
using BLL.Models;

public class AccountController : Controller
{

    UserService service;
    LoginService login_service;
    //IMapper mapper;       // To be added later

    public AccountController(UserService service, LoginService login_service)
    {
        this.service = service;
        this.login_service = login_service;
    }


    [HttpGet]
    public IActionResult Login()
    {
        return View(new LoginModel());              // value = @Model.UserName; the View expects a Model; so initially we send an empty object as Model Binding
    }

    [HttpPost]
    public IActionResult Login(LoginModel LoginModel)   // variable name mapping
    {
        if (ModelState.IsValid)
        {
            try
            {
                var User = login_service.GetUserByEmailAndPassword(LoginModel.Email, LoginModel.Password);
                if(User != null)
                {
                    // TODO: Store user info in session
                    // HttpContext.Session.SetString("UserId", user.UserId.ToString());
                    // HttpContext.Session.SetString("UserName", user.UserName);
                    // HttpContext.Session.SetString("Email", user.Email);
                    // HttpContext.Session.SetString("Role", user.Role);

                    return RedirectToAction("HomePage", "Main");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password");
                }
            }
            catch (Exception ex)
            {
                // Get the inner exception details
                var innerException = ex.InnerException?.Message ?? ex.Message;
                ModelState.AddModelError("", $"An error occurred: {innerException}");
                // Handle unexpected errors
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
            }

        }

        return View(LoginModel);
    }

    [HttpGet]
    public IActionResult Registration()
    {
        return View(new RegistrationModel());   // value = @Model.UserName ,  value = @Model.Email ... initially Model can't be null. but UserName = null, Email = null can be true, thats why create an empty object
    }

    [HttpPost]
    public IActionResult Registration(RegistrationModel RegistrationModel)
    {
        if (ModelState.IsValid)
        {
            var userModel = new UserModel
            {
                UserName = RegistrationModel.UserName,
                Email = RegistrationModel.Email,
                Password = RegistrationModel.Password,
                AccountStatus = RegistrationModel.AccountStatus,
                Role = RegistrationModel.Role,
                CreatedAt = DateTime.Now
            };

            try
            {
                var data = service.CreateUser(userModel);

                if (data)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Registration failed. Please try again.");     // general error
                }
            }
            catch(Exception ex)
            {
                // Get the inner exception details
                var innerException = ex.InnerException?.Message ?? ex.Message;
                ModelState.AddModelError("", $"An error occurred: {innerException}");
                // Handle unexpected errors
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
            }    
        }

        return View(RegistrationModel);
    }
}
