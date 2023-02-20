using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Practice.Helpers;
using Practice.Models;
using System.Reflection;

namespace Practice.Controllers
{
    [Route("form")]
    public class FormController : Controller
    {
        public IWebHostEnvironment iweb;

        public FormController(IWebHostEnvironment _iweb)
        {
            iweb = _iweb;
        }
        [Route("index")]
        //[Route("~/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("file")]
        //[Route("~/")]
        public IActionResult File(IFormFile file)
        {
            Debug.WriteLine(file.FileName);
            Debug.WriteLine(file.Length);
            Debug.WriteLine(file.ContentType);
            return View("Index");
        }

        [HttpPost]
        [Route("files")]
        //[Route("~/")]
        public IActionResult Files(IFormFile[] files)
        {
            if (files != null && files.Length > 0)
            {
                foreach (var file in files)
                {
                    Debug.WriteLine(file.FileName);
                    Debug.WriteLine(file.Length / 1024 / 1024 + "MB");
                    Debug.WriteLine(file.ContentType + "\n");
                }
            }
            return View("Index");
        }

        [HttpPost]
        [Route("upload")]
        //[Route("~/")]
        public IActionResult Upload(IFormFile[] upload)
        {
            if (upload != null && upload.Length > 0)
            {
                foreach (var up in upload)
                {
                    var path = Path.Combine(iweb.WebRootPath, "UploadImages", FileHelper.generationImage(up.FileName));

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        up.CopyToAsync(fileStream);
                    }
                }
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        [Route("uploadcsv")]
        public IActionResult UploadCSV(IFormFile[] uploadcsv)
        {
            if (uploadcsv != null && uploadcsv.Length > 0)
            {
                foreach (var up in uploadcsv)
                {
                    var path = Path.Combine(iweb.WebRootPath, "UploadImages", FileHelper.generationImage(up.FileName));

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        up.CopyToAsync(fileStream);
                    }
                    var lines = System.IO.File.ReadAllLines(path);
                    foreach (var line in lines)
                    {
                        var rs = line.Split(new char[] { ',' });

                        var students = new Students();

                        students.Id = Convert.ToInt32(rs[0]);
                        students.Name = rs[1];
                        students.Score = Convert.ToDouble(rs[2]);
                        students.Gender = Convert.ToBoolean(rs[3]);
                        students.Qty = Convert.ToInt32(rs[4]);
                        students.Picture = rs[5];
                        students.DoB = Convert.ToDateTime(rs[6]);

                        ViewBag.students = new List<Students>
                        {
                            new Students
                            {
                                Id = Convert.ToInt32(rs[0]),
                                Name = rs[1],
                                Score = Convert.ToDouble(rs[2]),
                                Gender = Convert.ToBoolean(rs[3]),
                                Qty = Convert.ToInt32(rs[4]),
                                Picture = rs[5],
                                DoB = Convert.ToDateTime(rs[6])
                            }
                        };

                        Debug.WriteLine(students.Id);
                        Debug.WriteLine(students.Name);
                        Debug.WriteLine(students.Score);
                        Debug.WriteLine((students.Gender) ? "Male" : "Female");
                        Debug.WriteLine(students.Qty);
                        Debug.WriteLine(students.Picture);
                        Debug.WriteLine(students.DoB + "\n");
                    }
                }
            }
            return View("index2");
        }

        [Route("index2")]
        public IActionResult Index2()
        {
            var model = new StudentModel();
            ViewBag.students = model.getAllStudent();

            return View("Index2");
        }
    }
};