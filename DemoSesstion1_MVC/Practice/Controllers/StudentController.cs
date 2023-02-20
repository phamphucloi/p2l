using Microsoft.AspNetCore.Mvc;
using Practice.Models;

namespace Practice.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    { 
        [Route("index")]
        //[Route("~/")]
        [Route("")]
        public IActionResult Index()
        {
            var student = new StudentModel();
            ViewBag.students = student.getAllStudent();
            return View();
        }

        [Route("details/{id}")]        
        public IActionResult Details(int id)
        {
            var student = new StudentModel();
            ViewBag.student = student.Details(id);
            return View("details");
        }

        [Route("searchByPrice")]
        public IActionResult searchByPrice(double min, double max)
        {
            ViewBag.min = min;
            ViewBag.max = max;
            var student = new StudentModel();
            ViewBag.students = student.searchByPrice(min, max);
            return View("Index");
        }

        [Route("searchByName")]
        public IActionResult searchByName(string name)
        {
            var student = new StudentModel();
            ViewBag.students = student.searchByName(name);
            ViewBag.name = name;
            return View("Index");
        }
    }
};

