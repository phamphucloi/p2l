using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseTyple.Helper;

namespace UseTyple;
internal class Tuples
{
    public static int Id { get; set; }
    public static string Name { get; set; }
    public void Stu(int id, string name)
    {
        List<int, string, string> l = new();
        Console.WriteLine($"{nameof(id)}={id} , {nameof(name)} = {name}");
    }


    public override string ToString()
    {
        return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}}}";
    }
}
