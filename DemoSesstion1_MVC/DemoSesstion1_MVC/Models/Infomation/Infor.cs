using System.ComponentModel.DataAnnotations;

namespace DemoSesstion1_MVC.Models.Infomation;

public class Infor
{
    public int Id { get; set; }
    [Required(ErrorMessage = "123")]
    public Name Names { get; set; }
    public int Country { get; set; }
    public Address Address { get; set; }
    public Personal Personal { get; set; }
    public string Avartar { get; set; } 
}
