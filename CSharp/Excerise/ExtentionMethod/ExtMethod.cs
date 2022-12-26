using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excerise.ExtentionMethod;
internal static class ExtMethod
{
    public static void ChangColor<T>(this T item, params ConsoleColor[] values)
    {
        Console.BackgroundColor= values[0];
        Console.ForegroundColor= values[1];
    }

    public static bool In<T>(this T obj, params T[] values)
    {
        return values.Contains(obj);
    }
}
