using Microsoft.AspNetCore.Mvc;
using BLL.Service;
using BLL.Models;

namespace AppLayerMVC.Controllers
{
    public class TutorOfferingController : Controller
    {
        TutorOfferingService service;
        public TutorOfferingController(TutorOfferingService service)
        {
            this.service = service;
        }
        public IActionResult GetAllTutorOfferings()
        {
            var data = service.GetAllTutorOfferingsWithInfo();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
