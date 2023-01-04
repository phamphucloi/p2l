using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study;
internal class List<T,S,S1>
{
    public static List<Tuple<T, S, S1>> ListStup { get; set; } = new();
    
    public static void Insert(T a, S b, S1 c)
    {
        ListStup.Add(new Tuple<T,S,S1>(a,b,c));
    }

    public static void Print()
    {
        foreach (var i in ListStup)
        {
            Console.WriteLine($"Id = {i.Item1}|| Name = {i.Item2} || Gender = {i.Item3} ||");
        }
    }

}
