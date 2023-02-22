using Microsoft.AspNetCore.Mvc.Routing;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DemoSesstion1_MVC.Models;

public partial class Employee
{
    public string userName { get; set; }

    public string passWord { get; set; }

    public string Email { get; set; }

    public string Website { get; set; }

    public int Age { get; set; }
}
