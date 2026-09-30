using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Service;
using BLL.Models;


namespace AppLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRequestController : ControllerBase
    {
        StudentRequestService service;
        public StudentRequestController(StudentRequestService service)
        {
            this.service = service;
        }

        [HttpGet("all/info")]
        public IActionResult GetAllStudentRequestsWithInfo()
        {
            var data = service.GetAllStudentRequestsWithInfo();
            return Ok(data);
        }

        [HttpGet("all")]
        public IActionResult GetAllStudentRequests()
        {
            var data = service.GetAllStudentRequests();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentRequestById(int id)
        {
            var data = service.GetStudentRequestById(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreateStudentRequest(StudentRequestModel StudentRequestModel)
        {
            var data = service.CreateStudentRequest(StudentRequestModel);

            if (data)
            {
                return Ok("StudentRequest Created Successfully!");
            }

            return BadRequest("StudentRequest Creation Failed!");
        }

        [HttpPut]
        public IActionResult UpdateStudentRequest(StudentRequestModel StudentRequestModel)
        {
            var data = service.UpdateStudentRequest(StudentRequestModel);

            if (data)
            {
                return Ok("StudentRequest Updated Successfully!");
            }

            return BadRequest("StudentRequest Update Failed!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudentRequest(int id)
        {
            var data = service.DeleteStudentRequest(id);

            if (data)
            {
                return Ok("StudentRequest deleted Successfully!");
            }

            return BadRequest("StudentRequest deletion failed!");
        }
    }
}
