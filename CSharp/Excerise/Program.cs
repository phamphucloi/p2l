using Excerise.Dal;
using Excerise.ExtentionMethod;
using Excerise.Helper;
using System.Text;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

Entity.Products pro = new();

Console.WriteLine("Vui lòng nhập id : ");
pro.Id = Validation<string>.CheckReadLine();

Console.WriteLine("Vui lòng nhập số lượng : ");
pro.Qty= Validation<int>.CheckReadLine();

ProductDAL dal = new();
dal.ChangColor(ConsoleColor.Black, ConsoleColor.Blue);
dal.AddProduct();

