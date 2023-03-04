using DemoSession2_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession2_MVC.Controllers
{
    [Route("demo")]
    public class DemoController : Controller
    {
        private DemoService demoService;
        public DemoController(DemoService _demoService) 
        {
            demoService = _demoService;
        }

        [Route("index")]
        //[Route("~/")]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.msg = demoService.Hello();
            return View();
        }
    }

};
