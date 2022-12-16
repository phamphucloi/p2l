namespace OOPAbtraction;
internal abstract class Cat:Animal
{
    private bool sex;

    public void ShowInfoCat()
    {
        Console.WriteLine($"{sex}={sex}");
    }
}
