using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEncapsulationProperty;
internal class Human
{
    //fields must be private;
    string fullName;

    //properties address
    public string Address { get; set; }


    public int Age { set; get; }

    //methods : getter, setter
    //public void setFullName(string fullName)
    //{
    //    this.fullName = fullName;
    //}

    //public string getFullName()
    //{
    //    return fullName;
    //}

    public string FullName
    {
        set => fullName = value;
      
        get => fullName;
    }

    public void ShowProp()
    {
        Console.WriteLine($"{nameof(Address)}={Address}");
        Console.WriteLine($"{fullName}={fullName}");
    }
}
