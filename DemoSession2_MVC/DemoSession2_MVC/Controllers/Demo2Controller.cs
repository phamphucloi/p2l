using DemoSession2_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession2_MVC.Controllers
{
    [Route("demo2")]
    public class Demo2Controller : Controller
    {
        private DemoService demoService;
        private HCNService hCNService;
        public Demo2Controller(DemoService _demoService, HCNService _hCNService)
        {
            demoService= _demoService;
            hCNService = _hCNService;
        }
        [Route("index2")]
        [Route("~/")]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.msg = demoService.Hi("Phạm Phúc Lợi");

            ViewBag.area = hCNService.Area(4,5);

            ViewBag.per = hCNService.Perimeter(4, 5);

            return View();
        }
    }

};
