using DemoSesstion1_MVC.Helpers;
using DemoSesstion1_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoSesstion1_MVC.Controllers
{
    [Route("demo3")]
    public class Demo3Controller : Controller
    {

        private IWebHostEnvironment iweb;
        public Demo3Controller(IWebHostEnvironment _iweb) 
        {
            iweb = _iweb;
        }


            //[Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet][Route("search_1")]
        public IActionResult Search1(string keyword)
        {
            Debug.WriteLine(keyword);
            return RedirectToAction("index");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string username, string password)
        {
            Debug.WriteLine(username, password);
            var hash = BCrypt.Net.BCrypt.HashPassword(password);
            var passdEnHash = "456";
            if (BCrypt.Net.BCrypt.Verify(passdEnHash, hash))
            {
                Debug.WriteLine("Valid");
            }
            else
            {
                Debug.WriteLine("Invalid");
            }
            Debug.WriteLine(username, hash);
            return RedirectToAction("index");
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(string[] emails, int[] quantity)
        {
            Debug.WriteLine("Emails : " + emails.Length);

            Debug.WriteLine("Quantity : " + quantity.Length);

            if (emails!= null && emails.Length > 0)
            {
                foreach (var i in emails)
                {
                    Debug.WriteLine(i);
                }
            }

            if (quantity != null && quantity.Length > 0)
            {
                foreach (var i in quantity)
                {
                    Debug.WriteLine(i);
                }
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        [Route("upload")]
        public IActionResult Upload(IFormFile name_files)
        {
            var gui = Guid.NewGuid().ToString().Replace("-", "");
            ViewBag.gui = gui;
            //Debug.WriteLine(name_files.FileName);
            //Debug.WriteLine(name_files.Length);
            //Debug.WriteLine(name_files.ContentType);
            //Upload Files
            //var nova = DateTime.Now.Microsecond;
            var path = Path.Combine(iweb.WebRootPath, "upload",gui + FileHelper.generateFileName(name_files.FileName));

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                Debug.WriteLine(fileStream);
                name_files.CopyTo(fileStream);
            }

            
            return RedirectToAction("index");
        }

        [HttpPost]
        [Route("uploads")]
        public IActionResult Upload(IFormFile[] files)
        {
            if (files!=null && files.Length > 0)
            {
                foreach (var i in files)
                {
                    var path = Path.Combine(iweb.WebRootPath, "upload", ViewBag.gui + FileHelper.generateFileName(i.FileName));

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        Debug.WriteLine(fileStream);
                        i.CopyTo(fileStream);
                    }
                }
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        [Route("importCSV")]
        public IActionResult ImportCSV(IFormFile file)
        {
            var path = Path.Combine(iweb.WebRootPath, "upload",FileHelper.generateFileName(file.FileName));

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                Debug.WriteLine(fileStream);
                file.CopyTo(fileStream);
            }
            var lines = System.IO.File.ReadAllLines(path);  
            foreach (var line in lines)
            {
                var rs = line.Split(new char[] {','});
                var pro = new Product();

                pro.Id = Convert.ToInt32(rs[2]);
                Debug.WriteLine(pro.Id);

            }

            return RedirectToAction("index");
        }
    }

};
