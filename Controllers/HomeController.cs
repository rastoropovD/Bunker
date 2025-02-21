using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BunkerApp.Models;

namespace BunkerApp.Controllers;

public abstract class Example
{
    private readonly string _data;
    protected Example()
    {
        _data = Guid.NewGuid().ToString();
    }

    public string GetData()
    {
        return _data;
    }
}

public class ScopedExample : Example
{
}

public class TransientExample : Example
{
}

public class SingletonExample : Example
{
}

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ScopedExample _scopedExample1;
    private readonly TransientExample _transientExample1;
    private readonly SingletonExample _singletonExample1;
    private readonly ScopedExample _scopedExample2;
    private readonly TransientExample _transientExample2;
    private readonly SingletonExample _singletonExample2;
    
    public HomeController(ILogger<HomeController> logger, 
        ScopedExample scopedExample, 
        TransientExample transientExample, 
        SingletonExample singletonExample,
        ScopedExample scopedExample2, 
        TransientExample transientExample2, 
        SingletonExample singletonExample2)
    {
        _logger = logger;
        _scopedExample1 = scopedExample;
        _transientExample1 = transientExample;
        _singletonExample1 = singletonExample;
        _scopedExample2 = scopedExample2;
        _transientExample2 = transientExample2;
        _singletonExample2 = singletonExample2;
    }

    public IActionResult Index()
    {
        string singletone1 = _singletonExample1.GetData();
        string singletone2 = _singletonExample2.GetData();
        
        string scoped1 = _scopedExample1.GetData();
        string scoped2 = _scopedExample2.GetData();
        
        string transient1 = _transientExample1.GetData();
        string transient2 = _transientExample2.GetData();
        
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