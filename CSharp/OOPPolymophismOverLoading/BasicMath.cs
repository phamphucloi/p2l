using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPolymophismOverLoading;
internal class BasicMath : Student
{
    //Auto properties
    public int Number1 { get; set; }
    public int Number2 { get; set; }



    //overloading only difference parameter or type arguments
    //1 is constructor, 2 is method
    //public BasicMath(){}


    //public BasicMath(int number1 = 0, int number2 = 0)
    //{
    //    Number1 = number1;
    //    Number2 = number2;
    //}

    public void Insert()
    {
        Student stu = new();
        stu.AddSV();
    }


}
