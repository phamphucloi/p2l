using DemoSession2_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession2_MVC.Controllers
{
    [Route("demo3")]
    public class Demo3Controller : Controller
    {
        public CalculateService calculateService;

        public Demo3Controller(CalculateService _calculateService) 
        { 
            calculateService= _calculateService;
        }

        [Route("index3")]
        //[Route("~/")]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.sum = calculateService.Sum(5,7);
            ViewBag.mul = calculateService.Mul(5,7);
            return View();
        }
    }

};
