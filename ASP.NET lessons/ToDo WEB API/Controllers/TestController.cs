using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDo_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Authorize(Policy ="CanTest")]
        [HttpGet("test")]
        public async Task<ActionResult> Test()
        {
            return Ok("It Works");
        }
    }
}
