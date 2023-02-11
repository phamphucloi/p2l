namespace Test2;
using System;
class Program
{
    static void Main(string[] args)
    {
        var n = new int[] {1,2,3,4};
        var sum = 0;
        for (int i = 0; i < n.Length; i++)
        {
            sum += n[i];
        }
        System.Console.WriteLine(sum);
    }
}
