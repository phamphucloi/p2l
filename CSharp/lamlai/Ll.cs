
using Baitap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamlai;
internal class Ll : Sinh
{
    public static void Test(int a, int b, int c)
    => Console.WriteLine($"{nameof(a)}={a}, {nameof(b)}={b}, {nameof(c)}={c}");

    public static void Ar(params int[] test)
    {
        int s = 0;
        foreach(var i in test)
        {
            s += i;
        }
        Console.WriteLine($"{nameof(s)}={s}");
    }

    public static void Ba()
    {
        Ll.Sinhhoc();
    }

}
