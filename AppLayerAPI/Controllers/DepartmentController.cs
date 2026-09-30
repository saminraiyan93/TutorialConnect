using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Service;
using BLL.Models;

namespace AppLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        DepartmentService service;
        public DepartmentController(DepartmentService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        public IActionResult GetAllDepartments()
        {
            var data = service.GetAllDepartments();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            var data = service.GetDepartmentById(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreateDepartment(DepartmentModel DepartmentModel)
        {
            var data = service.CreateDepartment(DepartmentModel);

            if (data)
            {
                return Ok("Department Created Successfully!");
            }

            return BadRequest("Department Creation Failed!");
        }

        [HttpPut]
        public IActionResult UpdateDepartment(DepartmentModel DepartmentModel)
        {
            var data = service.UpdateDepartment(DepartmentModel);

            if (data)
            {
                return Ok("Department Updated Successfully!");
            }

            return BadRequest("Department Update Failed!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var data = service.DeleteDepartment(id);

            if (data)
            {
                return Ok("Department deleted Successfully!");
            }

            return BadRequest("Department deletion failed!");
        }
    }
}
