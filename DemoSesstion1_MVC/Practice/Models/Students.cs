using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Practice.Models;

public class Students
{
    public int Id { get; set; }
    //[Required(ErrorMessage = "Not null")]
    public string Name { get; set; }
    public double Score { get; set;}
    public bool Gender { get; set;}
    //[Required(ErrorMessage = "Not null")]
    public int Qty { get; set;}
    public string Picture { get; set;}
    public DateTime DoB { get; set;}

    public override string ToString()
    {
        return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Score)}={Score.ToString()}, {nameof(Gender)}={Gender.ToString()}, {nameof(Qty)}={Qty.ToString()}, {nameof(Picture)}={Picture}, {nameof(DoB)}={DoB.ToString()}}}";
    }
}
