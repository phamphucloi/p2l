using Microsoft.AspNetCore.Mvc;
using Practice.Models;
using System.Diagnostics;

namespace Practice.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {

        [HttpGet]
        [Route("login")]
        //[Route("~/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        //[Route("~/")]
        public IActionResult Index(string username, string password)
        {
            if (username == "ppl" && password == "1")
            {
                return RedirectToAction("index", "student");
            }
            else
            {
                ViewBag.mess = "Invalid! Maybe error username or password";
                return View("Index");
            }
        }

        [HttpGet]
        [Route("~/")]
        [Route("register")]
        public IActionResult Register()
        {
            var acc = new Account();
            acc.UserName = "123";
            acc.Role = 2;
            acc.Cert = 1;

            acc.address = new Address();
            acc.address.Street = "123";
            acc.address.Ward = "456";

            var cert = new CertModel();
            ViewBag.certs = cert.getAllCert();

            var lang = new LanguagesModel();
            ViewBag.langs = lang.getAllLanguages();

            var role = new RoleModel();
            ViewBag.roles = role.getAllRoles();

            
            return View("Register",acc);
        }

        [HttpPost]
        [Route("register")]
        //[Route("~/")]
        public IActionResult Register(Account acc, int[] languages)
        {
            Debug.WriteLine(acc.UserName);
            Debug.WriteLine(acc.Password);
            Debug.WriteLine(acc.Description);
            Debug.WriteLine(acc.Cert);
            acc.Id_Languages = languages;
            foreach (var lang in acc.Id_Languages)
            {
                Debug.WriteLine("Languages : " + lang);
            }
            Debug.WriteLine(acc.Role);
            Debug.WriteLine(acc.address.Street);
            Debug.WriteLine(acc.address.Ward);
            if (acc.Password==null)
            {
                ViewBag.mess = "nhập pass";
                return RedirectToAction("register");
            }
            var hash = BCrypt.Net.BCrypt.HashPassword(acc.Password);
            Debug.WriteLine(hash);
            return RedirectToAction("register");
        }
    }

};
