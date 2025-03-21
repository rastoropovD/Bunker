using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BunkerApp.Models;

namespace BunkerApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        object? message = TempData.Peek("Message");
        
        if (message == null)
        {
            TempData["Message"] = "Welcome to Bunker!";
        } 
        
        string? messageStr = message as string;
        
        return View();
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