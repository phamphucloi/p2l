using Student;
using System.Text;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding= Encoding.Unicode;

var stu = new Class1();

int id,age;

string name, email;

Console.Write("Enter your Id : ");
id = Convert.ToInt16(Console.ReadLine());
stu.setId(id);
Console.Write("\n");

Console.Write("Enter your Name : ");
name = Console.ReadLine();
stu.setName(name);
Console.Write("\n");

Console.Write("Enter your Age : ");
age = Convert.ToInt16(Console.ReadLine());
stu.setAge(age);
Console.Write("\n");


Console.Write("Enter your Email : ");
email = Console.ReadLine();
stu.setEmail(email);
Console.Write("\n");

Console.WriteLine($"Your Id is : { stu.getId() } \nYour Name is : {stu.getName()} " +
                    $"\nYour Age is {stu.getAge()} years old \nYour Email is : {stu.getEmail()}");




Console.WriteLine($"Số tuổi của m là : {stu.getAge()}");

