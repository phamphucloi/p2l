using System.ComponentModel.DataAnnotations;

namespace DemoSesstion1_MVC.Models.Infomation;

public class Name
{
    [Required(ErrorMessage = "Invalid First-Name")]
    [MinLength(3)]
    [MaxLength(15)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Invalid Last-Name")]
    [MinLength(3)]
    [MaxLength(15)]
    public string LastName { get; set; }
}
