using DemoSesstion1_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoSesstion1_MVC.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        [HttpGet]
        [Route("login")]
        //[Route("~/")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string username, string password)
        {
            if (username=="123"&& password=="a")
            {
                return RedirectToAction("wellcome");
            }
            else
            {
                ViewBag.mess = "Invalid";
                return View("Login");
            }
        }

        [Route("wellcome")]
        //[Route("~/")]
        public IActionResult Wellcome()
        {
            return View("Wellcome");
        }

        [Route("logout")]
        //[Route("~/")]
        public IActionResult Logout()
        {
            return View("Login");
        }


        [Route("register")]
        //[Route("~/")]

        public IActionResult Register()
        {
            var ce = new CertModel();
            var lang = new LanguageModel();
            var role = new RoleModel();
            var account = new Account()
            {
                userName = "123",
                Description = "Phạm Phúc Lợi",
                passWord = "123",
                Cert = 1,
                Status = true,
                Role = 2,
                Id = 123,
                Address = new Address()
                {
                    Street = "123",
                    Ward= "1456",
                },
                DoB = DateTime.Now
            };
            ViewBag.ces = ce.findAll();
            ViewBag.lang = lang.findAll();
            ViewBag.roles = role.findAll();
            return View("Register", account);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(Account acc, int[] lang)
        {
            Debug.WriteLine(acc.userName);
            Debug.WriteLine(acc.passWord);
            Debug.WriteLine("Description : " + acc.Description);
            Debug.WriteLine("Gender : " + acc.Gender);
            Debug.WriteLine("Cert : " + acc.Cert);
            Debug.WriteLine("Status : " + acc.Status);
            Debug.WriteLine("Role : " + acc.Role);
            Debug.WriteLine("Id : " + acc.Id);
            acc.Languages= lang;
            foreach (var la in acc.Languages)
            {
                Debug.WriteLine("lang : " + la);
            }
            Debug.WriteLine("Street : " + acc.Address.Street);
            Debug.WriteLine("Ward : " + acc.Address.Ward);
            acc.passWord = BCrypt.Net.BCrypt.HashPassword(acc.passWord);

            Debug.WriteLine("hash : " + acc.passWord);
            Debug.WriteLine("Date Of Birth : " + acc.DoB.ToString("yyyy-MM-dd"));
            return RedirectToAction("register");
        }
    }

};
