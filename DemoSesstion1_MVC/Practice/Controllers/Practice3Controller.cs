using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Practice.Controllers
{
    [Route("practice3")]
    public class Practice3Controller : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        [Route("index2")]
        public IActionResult Index2(string username,string password)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(password);
            string pas = "123";
            if (BCrypt.Net.BCrypt.Verify(pas, hash))
            {
                Debug.WriteLine("Đúng");
            }
            else
            {
                Debug.WriteLine("Sai");
            }
            Debug.WriteLine("userName : " + username ,"password : " + password);
            return RedirectToAction("index2");

            //Debug.WriteLine(username, password);
            //var hash = BCrypt.Net.BCrypt.HashPassword(password);
            //var passdEnHash = "456";
            //if (BCrypt.Net.BCrypt.Verify(passdEnHash, hash))
            //{
            //    Debug.WriteLine("Valid");
            //}
            //else
            //{
            //    Debug.WriteLine("Invalid");
            //}
            //Debug.WriteLine(username, hash);
            //return RedirectToAction("index");
        }
    }
};
