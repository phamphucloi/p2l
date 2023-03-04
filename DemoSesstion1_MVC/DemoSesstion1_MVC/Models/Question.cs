namespace DemoSesstion1_MVC.Models;

public class Question
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Answer> Answer { get; set; }
}
