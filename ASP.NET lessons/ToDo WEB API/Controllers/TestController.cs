using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ToDo_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //private readonly ILogger _logger;

        //public TestController(ILogger<TestController> logger)
        //{
        //    _logger = logger;
        //}

        //[Authorize(Policy ="CanTest")]
        [HttpGet("test")]
        public async Task<ActionResult> Test()
        {
            //_logger.LogInformation("It's works -> 200 OK");
            Log.Error("test");
            Log.Information("It's works -> 200 OK");
            return Ok("It Works");
        }
    }
}
