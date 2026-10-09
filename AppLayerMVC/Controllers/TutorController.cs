using AppLayerMVC.Models;
using BLL.Models;
using BLL.Service;
using Microsoft.AspNetCore.Mvc;

namespace AppLayerMVC.Controllers
{
    public class TutorController : Controller
    {
        TutorOfferingService tutorOfferingService;
        CourseService courseService;
        StudentRequestService studentRequestService;
        public TutorController(TutorOfferingService tutorOfferingService, CourseService courseService, StudentRequestService studentRequestService)
        {
            this.tutorOfferingService = tutorOfferingService;
            this.courseService = courseService;
            this.studentRequestService = studentRequestService;
        }
        public IActionResult Index()
        {
            var tutorOffers = tutorOfferingService.GetAllTutorOfferingsWithInfo();
            return View(tutorOffers);
        }

        public IActionResult TutorOfferViewDetails(int id)
        {
            var tutorOffer = tutorOfferingService.GetTutorOfferingWithInfoById(id);
            return View(tutorOffer);
        }





        //[HttpGet]
        //public IActionResult PostTutoringRequest()
        //{
        //    var courses = courseService.GetAllCourseWithInfo();
        //    ViewBag.Courses = courses;
        //    ViewBag.UserName = HttpContext.Session.GetString("UserName");

        //    return View(new StudentRequestModel());
        //}

        //[HttpPost]
        //public IActionResult PostTutoringRequest(StudentRequestModel StudentRequestModel)
        //{
        //    var userId = HttpContext.Session.GetString("UserId");

        //    ViewBag.UserName = HttpContext.Session.GetString("UserName");

        //    if (string.IsNullOrEmpty(userId))
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.Courses = courseService.GetAllCourseWithInfo();
        //        return View(StudentRequestModel);
        //    }

        //    if (StudentRequestModel.BudgetType == "Free")
        //    {
        //        StudentRequestModel.BudgetPerLecture = 0;
        //    }

        //    StudentRequestModel.UserId = Convert.ToInt32(userId);
        //    StudentRequestModel.PostStatus = "Active";

        //    var data = studentRequestService.CreateStudentRequest(StudentRequestModel);

        //    if (data)
        //    {
        //        return RedirectToAction("Index", "Student");
        //    }

        //    ModelState.AddModelError("", "Unable to post tutoring request. Please try again.");
        //    ViewBag.Courses = courseService.GetAllCourseWithInfo();

        //    return View(StudentRequestModel);
        //}

    }
}
