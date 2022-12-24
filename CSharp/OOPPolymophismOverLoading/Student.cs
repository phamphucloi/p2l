using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPolymophismOverLoading;
internal class Student : Validation
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void AddSV()
    {
        Id = int.Parse(Regexs.CheckRegex(Validation.id, "Please enter id : "));

        Name = Regexs.CheckRegex(Validation.name, "Please enter your name : ");
    }
}
