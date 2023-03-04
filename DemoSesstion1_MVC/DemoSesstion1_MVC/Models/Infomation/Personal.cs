using System.ComponentModel.DataAnnotations;

namespace DemoSesstion1_MVC.Models.Infomation;

public class Personal
{
    [Required(ErrorMessage = "Invalid Phone")]
    [MinLength(1)]
    [MaxLength(4)]
    public string Phone { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = "Invalid DepartureDate")]
    public DepartureDate DepartureDate { get; set; }//ngày khởi hành
    [Required(ErrorMessage = "Invalid ArrivalDate")]
    public ArrivalDate ArrivalDate { get; set; }//ngày đến nơi
    [Required(ErrorMessage = "Invalid Status")]
    public bool Status { get; set; }
    [Required(ErrorMessage = "Invalid Notice")]
    public string Notice { get; set; }
}
