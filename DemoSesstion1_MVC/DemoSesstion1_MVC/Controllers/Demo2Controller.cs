using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoSesstion1_MVC.Controllers
{
    [Route("demo2")]
    public class Demo2Controller : Controller
    {
        //tag Helper
        public IActionResult Index()
        {
             return View();
        }

        [Route("index2")]
        public IActionResult Index2()
        {
            return View("Index2");
        }

        [Route("index3/{id}")]
        public IActionResult Index3(int id)
        {
            Debug.WriteLine(id);
            return View("Index3");
        }

        [Route("index4/{id}/{username}")]
        public IActionResult Index4(int id, string username)
        {
            Debug.WriteLine("id : " + id, "username : " + username);
            return View("Index4");
        }

        [Route("{index5}")]
        public IActionResult Index5(int id,string username)
        {
            Debug.WriteLine("id : " + id, "username : " + username);
            return View("Index5");
        }

        [Route("index6")]
        public IActionResult Index6()
        {
            //return RedirectToAction("Index2", "demo2");
            return RedirectToAction("index5", "demo2", new {id = 123, username="xyz"});
        }
    }
}
