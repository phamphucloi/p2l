using Microsoft.AspNetCore.Mvc;
using Practice.Models;
using System.Diagnostics;

namespace Practice.Controllers
{
    [Route("practice2")]
    public class Practice2Controller : Controller
    {
        //[Route("~/")]
        [Route("index")]
        public IActionResult Index(int id)
        {
            return View();
        }

        [Route("index2/{id}")]
        public IActionResult Index2(int id)
        {
            return View("Index2");
        }

        [Route("index3")]
        public IActionResult Index3(string user, string pass)
        {
            ViewBag.student = new List<Students>
            {
                new Students
                {
                    Id = 1,
                    Name = "Phạm Phúc Lợi",
                    Score = 9.0,
                    Gender = true,
                    Picture = "ppl.jpg",
                    Qty = 2,
                    DoB = DateTime.Now
                },

                new Students
                {
                    Id = 2,
                    Name = "Phạm Phúc Lợi 2",
                    Score = 8.0,
                    Gender = false,
                    Picture = "ppl.jpg",
                    Qty = 3,
                    DoB = DateTime.Now
                },

                new Students
                {
                    Id = 3,
                    Name = "Phạm Phúc Lợi 3",
                    Score = 9.0,
                    Gender = true,
                    Picture = "ppl.jpg",
                    Qty = 4,
                    DoB = DateTime.Now
                },

                new Students
                {
                    Id = 4,
                    Name = "Phạm Phúc Lợi 4",
                    Score = 8.0,
                    Gender = false,
                    Picture = "ppl.jpg",
                    Qty = 5,
                    DoB = DateTime.Now
                },

                new Students
                {
                    Id = 5,
                    Name = "Phạm Phúc Lợi 5",
                    Score = 9.0,
                    Gender = true,
                    Picture = "ppl.jpg",
                    Qty = 2,
                    DoB = DateTime.Now
                }
            };
            ViewBag.user = "ppl";
            ViewBag.pass = "1";

            if (ViewBag.user==user && ViewBag.pass==pass)
            {
                return RedirectToAction("Index4");
            }

            return View("Index3");
        }

        [Route("index4")]
        //[Route("~/")]
        public IActionResult Index4()
        {
            return View("Index4");
        }
    }
};