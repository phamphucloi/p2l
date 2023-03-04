using DemoSesstion1_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoSesstion1_MVC.Controllers
{
    [Route("employee")]
    public class EmployeeController : Controller
    {
        [Route("index")]
        //[Route("~/")]
        public IActionResult Index()
        {
            var emp = new Employee();
            return View("index",emp);
        }

        [HttpPost]
        [Route("index")]
        //[Route("~/")]
        public IActionResult Index(Employee emp)
        {
            //custom validation.
            if (emp.userName!=null && emp.userName == "abc")
            {
                ModelState.AddModelError("userName", "Username exists");
            }

            if (ModelState.IsValid)
            {
                Debug.WriteLine(emp.userName);
                Debug.WriteLine(emp.passWord);
                return View("success");
            }
            else
            {
                return View("index");
            }
        }

        [Route("success")]
        public IActionResult Success(Employee emp)
        {
            return View();
        }
    }

};
