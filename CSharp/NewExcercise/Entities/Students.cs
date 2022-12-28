namespace NewExcercise.Entities;
internal class Students
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public bool Gender { get; set; }
    public DateTime DoB { get; set; }
    public Double Score { get; set; }

    public override string ToString()
    {
        return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Gender)}={Gender.ToString()}, {nameof(DoB)}={DoB.ToString()}, {nameof(Score)}={Score.ToString()}}}";
    }
}
