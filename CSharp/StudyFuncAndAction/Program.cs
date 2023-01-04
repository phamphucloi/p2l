internal class Program
{
    public static void Sum(int a, int b) => Console.WriteLine(a + b);
    public static int Sub(int a, int b) => a-b;
    private static void Main(string[] args)
    {
        int Multi(int a, int b) => a * b;

        int A(int a) => a; ; 

        Action<int,int> a = Sum;
        a(4,5);

        Func<int,int,int> f = Sub;
        Console.WriteLine(f(4,5));

        Func<int,int, int> ac = Multi;
        ac(6,8);

        //Action<int, int> at = Multi;
        //at(5,6);

        Func<int , int> t = A;
        Console.WriteLine(t(5));

    }
}