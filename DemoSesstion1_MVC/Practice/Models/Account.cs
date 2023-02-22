namespace Practice.Models;

public class Account
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
    public int Cert { get; set; }
    public int[] Id_Languages { get; set; }
    public int Role { get; set; }
    public Address address { get; set; }
}
