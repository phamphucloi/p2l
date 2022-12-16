using System.Text;
using System.Text.RegularExpressions;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

//string? str = null;

//Console.Write("Enter the number : ");

//str= Console.ReadLine();

//var formula = new Regex(@"/d+");

//if (formula.IsMatch(str))
//{
//    int rs = Convert.ToInt32(str);
//    Console.WriteLine(rs);
//}

//if (int.TryParse(str, out int i))
//{
//    Console.WriteLine($"{nameof(i)}={i}");
//}

Console.WriteLine("Please enter quantity : ");
string? amount = Console.ReadLine();
//use try catch
//statement "guard clause"
if (string.IsNullOrEmpty(amount))
{
    return;
}

try
{
    int total = int.Parse(amount);
    if (total <= 0) throw new Exception("have to > 0");
    Console.WriteLine($"{nameof(total)}={total}");
}
catch (Exception) when (amount.Contains("$"))
{
    Console.WriteLine("String haven't &");
}
catch (FormatException e)
{
    Console.WriteLine($"{e.GetType()}, {e.Message}");
}

////do something
////=================================
//if(amount != null)
//{
//    //do something
//}