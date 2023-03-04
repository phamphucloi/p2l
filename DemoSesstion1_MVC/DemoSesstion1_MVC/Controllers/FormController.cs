using DemoSesstion1_MVC.Helpers;
using DemoSesstion1_MVC.Models.Infomation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace DemoSesstion1_MVC.Controllers
{
    [Route("form")]
    public class FormController : Controller
    {
        IWebHostEnvironment iweb;

        public FormController(IWebHostEnvironment _iweb)
        {
            iweb= _iweb;
        }

        //[Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            var info = new Infor();
            ViewBag.avartar = info.Avartar;
            var countryModel = new CountryModel();
            ViewBag.country = countryModel.GetAll();

            return View("index", info);
        }

        [HttpPost]
        [Route("index")]
        public IActionResult Index(Infor info, IFormFile[] files)
        {
            if (files != null && files.Length > 0)
            {
                foreach (var file in files)
                {
                    Debug.WriteLine(file.FileName);
                    Debug.WriteLine(file.Length);
                    Debug.WriteLine(file.ContentType + "\n");

                    var path = Path.Combine(iweb.WebRootPath, "imgs", FileHelper.generateFileName(file.FileName));

                    //info.Avartar = file.Name;
                    //ViewBag.avartar = info.Avartar;

                    using (var stream = new FileStream(path,FileMode.Create))
                    {
                        file.CopyTo(stream);

                    }
                }
            }

            if (info.Names.FirstName == null)
            {
                ModelState.AddModelError("FirstName", "Not null");
            }

            Debug.WriteLine("Country : " + info.Country);
            Debug.WriteLine("First Name : " + info.Names.FirstName);
            Debug.WriteLine("Last Name : " + info.Names.LastName);
            Debug.WriteLine("Status : " + info.Personal.Status);
            Debug.WriteLine("Phone : " + info.Personal.Phone);
            Debug.WriteLine("Email : " + info.Personal.Email);
            Debug.WriteLine("ArrivalDate.Month : " + info.Personal.ArrivalDate.Month.ToString("MM"));
            Debug.WriteLine("ArrivalDate.Day : " + info.Personal.ArrivalDate.Day.ToString("dd"));
            Debug.WriteLine("ArrivalDate.Year : " + info.Personal.ArrivalDate.Year.ToString("yyyy"));

            Debug.WriteLine("DepartureDate.Month : " + info.Personal.DepartureDate.Month.ToString("MM"));
            Debug.WriteLine("DepartureDate.Day : " + info.Personal.DepartureDate.Day.ToString("dd"));
            Debug.WriteLine("DepartureDate.Year : " + info.Personal.DepartureDate.Year.ToString("yyyy"));
            Debug.WriteLine("Notice : " + info.Personal.Notice);
            return RedirectToAction("index");
        }
    }

};
