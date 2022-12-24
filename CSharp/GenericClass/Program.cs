
using GenericClass;
using System.Text;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding= Encoding.Unicode;

//điều kiện dùng generic class là các class phải có chung field và chung kiểu dữ liệu 
Class1<int> one = new();
one.Field = 10;
one.Show();

//Class2<string> hai = new();
//hai.Name = "Lợi";
//hai.Description = "Project Managerment";
//hai.Show();

Class2<string, int> ba = new();
ba.Name = "Lợi";
ba.Description = 19;
ba.Show();