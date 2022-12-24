using _21_12_2022;
using System.Text;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;
Console.Write("Please enter a numebr : ");
int i = int.TryParse(Console.ReadLine(),out var rs)?rs:0;

//checking i largest 100?;
CheckNum.Check(i,100);

i.ExCheck(100);

Program pro = new();

pro.Hi();

//extention method không thông qua object containing;
//thông qua user to;(cái muốn sử dụng);
