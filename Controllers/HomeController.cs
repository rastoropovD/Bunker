using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BunkerApp.Models;
using Microsoft.Extensions.Options;

namespace BunkerApp.Controllers;

public sealed class TestSingle
{
    private readonly IOptionsMonitor<TestConfigModel> _monitor;

    private TestConfigModel _value2;
    
    public TestSingle(IOptionsMonitor<TestConfigModel> monitor)
    {
        _monitor = monitor;
        //_snapshot = snapshot;

    //    _value1 = snapshot.Value;
        _value2 = monitor.CurrentValue;

        _monitor.OnChange(v =>
        {
            _value2 = v;
        });
    }
    
    

    public TestConfigModel GetValues()
    {
        return _value2;
    }
}


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly TestSingle _testSingle;
    
    public HomeController(ILogger<HomeController> logger, TestSingle testSingle, IOptionsMonitor<TestConfigModel> monitor, IOptionsSnapshot<TestConfigModel> snapshot)
    {
        _logger = logger;
        _testSingle = testSingle;
    }

    public IActionResult Index()
    {
        var data = _testSingle.GetValues();
        
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