using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Service;
using BLL.Models;

namespace AppLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService service;
        public UserController(UserService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            var data = service.GetAllUsers();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var data = service.GetUserById(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreateUser(UserModel UserModel)
        {
            var data = service.CreateUser(UserModel);

            if (data)
            {
                return Ok("User Created Successfully!");
            }

            return BadRequest("User Creation Failed!");
        }

        [HttpPut]
        public IActionResult UpdateUser(UserModel UserModel)
        {
            var data = service.UpdateUser(UserModel);

            if (data)
            {
                return Ok("User Updated Successfully!");
            }

            return BadRequest("User Update Failed!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var data = service.DeleteUser(id);

            if (data)
            {
                return Ok("User deleted Successfully!");
            }

            return BadRequest("User deletion failed!");
        }
    }
}
