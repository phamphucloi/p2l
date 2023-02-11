using Microsoft.AspNetCore.Mvc;

namespace DemoSesstion1_MVC.Controllers;
public class DemoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Index2()
    {
        return View("Index2");
    }

    public IActionResult Index3()
    {
        return View("Index3");
    }
}
