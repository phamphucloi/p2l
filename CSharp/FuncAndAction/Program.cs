//delegate void Display();

internal class Program
{
    public static void Add(int a, int b) => Console.WriteLine(a + b);

    public static int Subc(int a, int b) => a - b;

    public static void Show() => Console.WriteLine("C2109I1");

    public static int ReturnNum() => 5;

    private static void Main(string[] args)
    {
        void Sub(int a, int b) => Console.WriteLine(a-b);
        //local function

        //func and action => delegate

        //action use for method have void;

        //func use for method different void;
        Action a = Show;
        a();
        //a = Sub;

        Action<int, int> ac = Add;
        ac(4,6);

        Func<int> fun = ReturnNum;
        Console.WriteLine(fun());

        Func<int, int, int> f = Subc;
        Console.WriteLine(f(10, 2));

        Action<string> action = (str) =>
        {
            Console.WriteLine(str);
        };

        action("123");
    }

}