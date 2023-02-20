using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        [Route("~/")]
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            var student = new StudentModel();
            ViewBag.students = student.getAllStudent();
            return View();
        }
    }
};
