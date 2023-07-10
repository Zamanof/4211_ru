using Filters_.Filters;
using Filters_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

using System.Diagnostics;

namespace Filters_.Controllers;
//[TypeFilter(typeof(ApiKeyQueryAutorization))]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [DateTimeExec]
    public IActionResult Index()
    {
        throw new KeyNotFoundException();
        return View();

    }
    [LastEnterDate]
    public IActionResult Privacy()
    {
        int a =0;
        int b = 5 / a;
        return View();
    }
    //[TypeFilter(typeof(MyAutorizationFilter))]
    public IActionResult Welcome()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}