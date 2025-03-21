using BunkerApp.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace BunkerApp.Controllers;

public sealed class CreateUserController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View("../User/CreateUserView");
    }

    [HttpPost]
    public IActionResult Index(CreateUserModel model)
    {
        if (ModelState.IsValid)
        {
            // server-side validation
            // visible only with All validation summary
            // if validation error then return view with model 
            ModelState.AddModelError("", "Error message that is not direct ot specific field");

            // it model is valid then call business logic and redirect to another page (home or list)
            
            return RedirectToAction("Index", "Home");
        }
        
       
        return View("../User/CreateUserView", model);
    }
}