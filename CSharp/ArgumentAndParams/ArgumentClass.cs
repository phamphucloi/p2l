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


}
