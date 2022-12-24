using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGro;
public class Product
{
    public static int Id { get; set; }
    public static string Name { get; set; }

    public static int Gender { get; set; }

    private static int id;
    private static string name;
    public Product() { }

    public void AddPro()
    {
        Id= int.Parse(Validation.CheckRegex(Regexx.ID, "Please enter id : "));
        while (string.IsNullOrEmpty(Name))
        {
            Name = Validation.CheckRegex(Regexx.NAME, "Please enter your name : ");
        }
        Console.WriteLine("==========0 is female || 1 is male==========");
        Gender = int.Parse(Validation.CheckRegex(Regexx.GENDER, "Plase enter your gender : "));

    }
}
