using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_12_2022;
//biến this class thành extention method
//=>class compulsory static
//a class is static, all in class is static
internal static class ExtentionCheck
{
    public static void ExCheck(this int i, int val)
    {
        //Console.WriteLine($"{ (i > val) ? "true":"false"}");
        if(i > val)
        {
            Console.WriteLine($"{i} largest {val}");
            return;
        }
        Console.WriteLine("Ngu");
    }

    public static void Hi(this Program pg) => Console.WriteLine("123");
}
