using System.Collections;
using System.Text;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

string[] arr = { "lợi", "123", "3456", "1512" };

//foreach(var ar in arr)
//{
//    Console.WriteLine($"{ar} có chiều dài là {ar.Length}");
//}

//int i = 0;
//while (i < arr.Length)
//{
//    Console.WriteLine($"{arr[i]} có chiều dài {arr[i].Length}");
//    i++;
//}

IEnumerator e = arr.GetEnumerator();
while (e.MoveNext())
{
    string s = (string)e.Current;
    Console.WriteLine($"{s} có chiều dài là {s.Length}");
}