namespace PhamPhucLoi_C2109I1;
internal class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Boolean Gender { get; set; }
    public DateOnly DoB { get; set; }

    public override string ToString() => $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Gender)}={(bool.Parse(Gender.ToString())==true?" Female":" Male")}, {nameof(DoB)}={DoB.ToString()}}}";
}
