namespace DemoSession2_MVC.Services;

public class CalculateServiceImpl : CalculateService
{
    public int Mul(int a, int b)
    {
        return a * b;
    }

    public int Sum(int a, int b)
    {
        return a + b;
    }
}
