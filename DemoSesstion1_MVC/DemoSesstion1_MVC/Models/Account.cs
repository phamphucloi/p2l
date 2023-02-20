namespace DemoSesstion1_MVC.Models;

public class Account
{
    public int Id { get; set; }
    public string userName { get; set; }
    public string passWord { get; set; }
    public string Description { get; set; }
    public string Gender { get; set; }
    public int Cert { get; set; }
    public bool Status { get; set; }
    public int[] Languages { get; set; }
    public int Role { get; set; }
    public Address Address { get; set; }
}
