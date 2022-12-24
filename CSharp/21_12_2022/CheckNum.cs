using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_12_2022;
internal class CheckNum
{
    public static void Check(int value, int i)
    {
        if(i > value)
        {
            Console.WriteLine($"{i} largest {value}");
        }
    }
}
