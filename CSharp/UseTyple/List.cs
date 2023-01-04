using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UseTyple;
internal class List<I,S,D>
{
    public static List<Tuple<I, S, D>> ListStu = new();

    public void Stu(I id, S name, D addr)
    {
        ListStu.Add(new Tuple<I , S, D>(id, name, addr));
        //Console.WriteLine("Nhập id : ");
        //int id = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Nhập name : ");
        //string name = Console.ReadLine();

        //var tup = (id, name);

        //ListStu.Add(tup);

        //Tuples tu = new();
        //tu.Stu(id,name);
        //ListStu.Add(tu);

        //foreach (var i in ListStu)
        //{
        //    Console.WriteLine(i);
        //}
    }

    public static void Print()
    {
        foreach (var i in ListStu)
        {
            Console.WriteLine($"Id = {i.Item1} || Name = {i.Item2} || Address : {i.Item3}");
        }
    }

    public override string ToString()
    {
        return $"{{}}";
    }
}
