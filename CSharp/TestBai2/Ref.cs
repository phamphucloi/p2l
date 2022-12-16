using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBai2;
internal class Ref
{
    public static void Reff(ref int a,ref int b){
        int temp = a;
        a = b;
        b = temp;
        Console.WriteLine($"{nameof(a)}={a} ; {nameof(b)}={b}");
    }
}
