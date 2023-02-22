using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DemoSesstion1_MVC.Models;

public class EmployeeMetaData
{
    [Required(ErrorMessage = "Username not empty")]
    [MinLength(3)]
    [MaxLength(5)]
    public string userName { get; set; }

    [Required(ErrorMessage = "Password not empty")]
    [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})")]
    public string passWord { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email not empty")]
    public string Email { get; set; }

    [Url]
    public string Website { get; set; }

    [Range(18, 100)]
    public int Age { get; set; }
}

[ModelMetadataType(typeof(EmployeeMetaData))]
public partial class Employee{}
