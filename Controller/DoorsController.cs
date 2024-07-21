using Microsoft.AspNetCore.Mvc;

namespace DoorsSecurity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoorsController : ControllerBase 
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok("Hello World");
        }
    }
}