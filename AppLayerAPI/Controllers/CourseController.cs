using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Service;
using BLL.Models;

namespace AppLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        CourseService service;
        public CourseController(CourseService service)
        {
            this.service = service;
        }

        [HttpGet("all/info")]
        public IActionResult GetAllCourseWithInfo()         // Get Course With Department Name
        {
            var data = service.GetAllCourseWithInfo();
            return Ok(data);
        }

        [HttpGet("all")]
        public IActionResult GetAllCourses()
        {
            var data = service.GetAllCourses();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            var data = service.GetCourseById(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreateCourse(CourseModel CourseModel)
        {
            var data = service.CreateCourse(CourseModel);

            if (data)
            {
                return Ok("Course Created Successfully!");
            }

            return BadRequest("Course Creation Failed!");
        }

        [HttpPut]
        public IActionResult UpdateCourse(CourseModel CourseModel)
        {
            var data = service.UpdateCourse(CourseModel);

            if (data)
            {
                return Ok("Course Updated Successfully!");
            }

            return BadRequest("Course Update Failed!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var data = service.DeleteCourse(id);

            if (data)
            {
                return Ok("Course deleted Successfully!");
            }

            return BadRequest("Course deletion failed!");
        }
    }
}
