using Microsoft.AspNetCore.Mvc;

namespace Practice.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {

        [HttpGet]
        [Route("login")]
        //[Route("~/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        //[Route("~/")]
        public IActionResult Index(string username, string password)
        {
            if (username == "ppl" && password == "1")
            {
                return RedirectToAction("index", "student");
            }
            else
            {
                ViewBag.mess = "Invalid! Maybe error username or password";
                return View("Index");
            }

        }
    }

};
