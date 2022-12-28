using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate;

delegate void Test(int a, int b);
internal class Mathems
{
    public void Sum(int a, int b) => Console.WriteLine($"{nameof(a)}={a} , {nameof(b)}={b} = {a+b}");
    public void Sub(int a, int b) => Console.WriteLine($"Sub {a-b}");
    public static void Multi(int a, int b) => Console.WriteLine($"Multi {a*b}");
    public void  Dev(int a, int b) => Console.WriteLine($"Dev {a / b}");
}
