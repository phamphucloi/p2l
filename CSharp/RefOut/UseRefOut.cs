namespace RefOut;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class UseRefOut
{
    //expression body
    //khi phương thức chỉ có 1 câu lệnh duy nhất.
    public void ShowInfo() => Console.WriteLine("Information about This Class");

    public static void ChangeNum(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
        Console.WriteLine($"Change number {nameof(a)}={a}, {nameof(b)}={b}");
    }


}
