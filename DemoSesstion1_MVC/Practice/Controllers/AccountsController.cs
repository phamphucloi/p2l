using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;
using Practice.Helpers;
using System.Diagnostics;

namespace Practice.Controllers
{
    [Route("accounts")]
    public class AccountsController : Controller
    {
        public IWebHostEnvironment iweb;
        public AccountsController(IWebHostEnvironment _iweb) 
        {
            iweb = _iweb;
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string username,string password)
        {
            if (username == "123" && password == "a")
            {
                return View("wellcome");
            } 
            else
            {
                ViewBag.mess = "sai tk or pass";
                return View("Login");
            }
        }

        [HttpPost]
        [Route("file")]
        public IActionResult File(IFormFile file)
        {
            if(file!=null && file.Length > 0)
            {
                if (Unitilies.GetTypeFile(file.FileName) != ".jpg")
                {
                    ProcessExtImages(file);
                }
                else
                {
                    ViewBag.type = "chi chua .png";
                    return View("wellcome");
                }
            }
            return View("login");
        }

        private void ProcessExtImages(IFormFile file)
        {
            var path = Path.Combine(iweb.WebRootPath, "UploadImages", Unitilies.ProcessImage(file.FileName));

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }

        [HttpPost]
        [Route("files")]
        public IActionResult Files(IFormFile[] files)
        {
            if (files != null && files.Length > 0)
            {
                foreach (var file in files)
                {
                    if (Unitilies.GetTypeFile(file.FileName)==".png")
                    {
                        Debug.WriteLine(file.FileName); Debug.WriteLine(file.Length/1024/1024); Debug.WriteLine(file.ContentType);
                        ProcessExtImages(file);
                    }
                    else
                    {
                        ViewBag.type = "chi chua .png";
                        return View("wellcome");
                    }
                }
            }
            return View("login");
        }
    }

};
