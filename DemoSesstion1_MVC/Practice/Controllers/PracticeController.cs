using Microsoft.AspNetCore.Mvc;

namespace Practice.Controllers;
public class PracticeController : Controller
{
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Index2()
    {
        return View("Index2");
    }
}
