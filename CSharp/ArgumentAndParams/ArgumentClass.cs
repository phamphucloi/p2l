using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentAndParams;
internal class ArgumentClass
{
    public void Display(int a, int b, int c) 
        => Console.WriteLine($"{nameof(a)}={a}, {nameof(b)}={b}, {nameof(c)}={c}");
    
    //optional argument
    public void Show(int a = 0, int b = default, int c=10) 
        => Console.WriteLine($"{nameof(a)}={a}, {nameof(b)}={b}, {nameof(c)}={c}");

    public void SumParam(params int[] values)
    {
        int sum = 0;
        foreach(var i in values)
        {
            sum += i;
        }

        Console.WriteLine($"{nameof(sum)}={sum}");
    }
}
