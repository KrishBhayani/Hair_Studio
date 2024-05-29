using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hair_Studio.Models;
using Hair_Studio.BAL;

namespace Hair_Studio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    //[CheckAccess]
    public IActionResult Index()
    {
        string controllerName  = "SEC_User";
        string actionName = "Index";
        string areaName = "SEC_User";
     
            return View($"~/Areas/{areaName}/Views/{controllerName}/{actionName}.cshtml");
        
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

