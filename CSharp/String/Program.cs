//Bài 1:
Console.WriteLine("Nhập số phần tử có trong chuỗi : ");
int n = int.Parse(Console.ReadLine());
string[] str = new string[n];

for (int i = 0; i < str.Length; i++)
{
    Console.WriteLine("Nhập phần tử thứ : " + i);
    str[i] = Console.ReadLine();
    if (str[i]==".")
    {
        return;
    }
    Console.WriteLine(string.Format("-----{0,5}-----", str[i]));
}

//Bài 2:
//int count = 0;
//Console.WriteLine("Nhập số phần tử có trong chuỗi : ");
//int n = int.Parse(Console.ReadLine());
//string[] str = new string[n];



//for (int i = 0; i < str.Length; i++)
//{
//    Console.WriteLine("Nhập phần tử thứ : " + i);
//    str[i] = Console.ReadLine();
//    if (str[i] == str[i])
//    {
//        count++;  
//    }

//    if (count <= 0)
//    {
//        Console.WriteLine("đã vào đây");
//        Console.WriteLine("------>" +str[i]);
//    }
//}