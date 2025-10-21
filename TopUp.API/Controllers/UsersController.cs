using Microsoft.AspNetCore.Mvc;

namespace TopUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController()
        {
 
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok();
        }
    }
}
