using Microsoft.AspNetCore.Mvc;
using Practice.Helpers;
using Practice.Models.Test;
using System.Diagnostics;

namespace Practice.Controllers
{
    [Route("personal")]
    public class PersonalController : Controller
    {
        public IWebHostEnvironment iweb;
        public PersonalController(IWebHostEnvironment _iweb) 
        { 
            iweb = _iweb;
        }

        [Route("index")]
        //[Route("~/")]
        public IActionResult Index()
        {
            var gen = new GenderModel();
            ViewBag.gender = gen.GetGender();

            var skill = new SkillModel();
            ViewBag.skills = skill.GetSkill();

            var friend = new FriendModel();
            ViewBag.friends = friend.GetFriends();
            return View();
        }

        [HttpPost]
        [Route("index")]
        public IActionResult Index(Info inf, int[] Skill, IFormFile[] files)
        {

            Debug.WriteLine(inf.Id);
            Debug.WriteLine(inf.Name);
            Debug.WriteLine(inf.Gender);
            inf.Skill = Skill;
            foreach (var skill in inf.Skill)
            {
                Debug.WriteLine("Những kĩ năng : " + skill);
            }
            Debug.WriteLine("Friends : " + inf.Friends);

            inf.Images = files;


            if (inf.Images != null && inf.Images.Length > 0)
            {
                Debug.WriteLine("Đã vào đây");
                ViewBag.mess = "123";
                foreach (var file in inf.Images)
                {
                    var path = Path.Combine(iweb.WebRootPath, "UploadImages", SupportFile.ForFile(file.FileName));

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        Debug.WriteLine($"File Name : {file.FileName}");
                        Debug.WriteLine($"Dung lượng : {file.Length}");
                        Debug.WriteLine($"Type : {file.ContentType}");
                    }
                }
            }

            return RedirectToAction("index", inf);
        }
    }

};
