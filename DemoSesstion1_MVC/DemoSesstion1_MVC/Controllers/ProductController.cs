using DemoSesstion1_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoSesstion1_MVC.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        //[Route("~/")]
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            var pro = new ProductModel();
            ViewBag.products = pro.findAll();
            return View();
        }

        [Route("details/{id}")]
        public IActionResult Details(int id)
        {
            var pro = new ProductModel();
            ViewBag.product = pro.Details(id);
            return View("Details");
        }

        [Route("searchByKeyword")]
        public IActionResult SearchByKeyword(string keyword)
        {
            var pro = new ProductModel();
            ViewBag.products = pro.SearchByKeyword(keyword);
            ViewBag.keyword = keyword;
            return View("Index");
        }

        [Route("searchByPrice")]
        public IActionResult SearchByPrice(double min, double max)
        {
            var pro = new ProductModel();
            ViewBag.products = pro.SearchByPrice(min, max);
            ViewBag.min = min;
            ViewBag.max = max;
            return View("Index");
        }
    }
};
