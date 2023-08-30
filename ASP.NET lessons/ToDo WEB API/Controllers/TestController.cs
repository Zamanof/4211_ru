using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
//using Serilog;

namespace ToDo_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly RoleManager<IdentityRole> _roleManager;

        public TestController(
            ILogger<TestController> logger,
            IMemoryCache memoryCache,
            RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _memoryCache = memoryCache;
            _roleManager = roleManager;
        }

        //[Authorize(Policy ="CanTest")]
        //[ResponseCache(Duration = 30)]
        [HttpGet("test")]
        public async Task<ActionResult> Test()
        {
            if (_memoryCache.TryGetValue("test", out var data))
            {
                return Ok(data);
            }
            else
            {
                await Task.Delay(3000);
                _memoryCache.Set("test", "It's works -> 200 OK",
                    new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromSeconds(3)
                    }) ;
                return Ok("It's works -> 200 OK");
            }


            //await Task.Delay(3000);
            //_logger.LogInformation("It's works -> 200 OK");
            //Log.Error("test");
            //Log.Information("It's works -> 200 OK");
            //return Ok("It Works");
        }
        [HttpPost("Add Role")]
        public async Task<ActionResult> AddRole(string roleName)
        {
            if (!_roleManager.RoleExistsAsync(roleName).Result)
            {
                var role = new IdentityRole(roleName);
                await _roleManager.CreateAsync(role);
            }
            return Ok();
        }
    }
}
