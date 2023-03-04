namespace DemoSession2_MVC.Services;

public class HCNServiceImpl : HCNService
{

    public CalculateService calculateService;
    public HCNServiceImpl(CalculateService _calculateService)
    {
        calculateService = _calculateService;
    }

    public int Area(int a, int b)
    {
       return calculateService.Mul(a, b);
    }

    public int Perimeter(int a, int b)
    {
        return calculateService.Mul(calculateService.Sum(a,b), 2);
    }
}
