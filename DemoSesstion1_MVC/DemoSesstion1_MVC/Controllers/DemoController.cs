using DemoSesstion1_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoSesstion1_MVC.Controllers;
public class DemoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Index2()
    {
        return View("Index2");
    }

    public IActionResult Index3()
    {
        return View("Index3");
    }

    public IActionResult Index4()
    {
        return View("Index4");
    }

    public IActionResult Index5()
    {
        ViewBag.Id = 123;
        ViewBag.UserName = "phamphucloi132";
        ViewBag.Pic = "327308453_917558602598567_2671577435100712797_n.jpg";
        ViewBag.Status = true;
        ViewBag.Price = 6.1;
        ViewBag.Qty = 5;

        ViewBag.Name = new List<String>
        {
            "P1","P2","P3"
        };

        ViewBag.Product = new Product(){
            Id = 1,
            Name = "PPL",
            Photo = "327308453_917558602598567_2671577435100712797_n.jpg",
            Price = 3.5,
            Qty = 3,
            Created = DateTime.Now
        };

        ViewBag.Pro = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "PPL",
                Photo = "327308453_917558602598567_2671577435100712797_n.jpg",
                Price = 3.5,
                Qty = 3,
                Created = DateTime.Now
            },
                        new Product
            {
                Id = 2,
                Name = "PPL",
                Photo = "327308453_917558602598567_2671577435100712797_n.jpg",
                Price = 3.5,
                Qty = 3,
                Created = DateTime.Now
            },
                                    new Product
            {
                Id = 3,
                Name = "PPL",
                Photo = "327308453_917558602598567_2671577435100712797_n.jpg",
                Price = 3.5,
                Qty = 3,
                Created = DateTime.Now
            },
                                                new Product
            {
                Id = 4,
                Name = "PHạm Phúc Lợi",
                Photo = "327308453_917558602598567_2671577435100712797_n.jpg",
                Price = 3.5,
                Qty = 3,
                Created = DateTime.Now
            },

        };

        return View("Index5");
    }
}
