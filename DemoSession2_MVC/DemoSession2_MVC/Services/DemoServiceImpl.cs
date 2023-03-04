namespace DemoSession2_MVC.Services;

public class DemoServiceImpl : DemoService
{
    public string Hello()
    {
        return "Hello";
    }

    public string Hi(string fullname)
    {
        return "hi " + fullname;
    }
}
