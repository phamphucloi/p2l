Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

int num1 = Random.Shared.Next(0,9);
int num2 = Random.Shared.Next(0,9);
Console.WriteLine($"{nameof(num1)} = {num1}");
Console.WriteLine($"{nameof(num2)} = {num2}");
Console.WriteLine("please enter mark : ");

var ope = Console.ReadLine();

switch (ope)
{
    case "+" when num1 > 0 && num2 > 0:  Console.WriteLine(num1 + num2); break;
    case "-" when num1 > num2: Console.WriteLine(num1 - num2); break;
    case "*": Console.WriteLine(num1 * num2); break;
    case "/" when num2 != 0 : Console.WriteLine(num1 / num2); break;
    case "%": Console.WriteLine(num1 % num2); break;

    default:
        Console.WriteLine("Bye...");
        break;
}

//biểu thức expression => biểu thức switch;
Console.WriteLine(
    ope switch
    {
        "+" when num1 > 0 && num2 > 0   => num1 + num2,
        "-" when num1 > num2            => num1 - num2,
        "*"                             => num1 * num2,
        "/" when num2 != 0              => num1 / num2,
        "%"                             => num1 % num2
    });