namespace C2109I1_Pham_Phuc_Loi.Entities;
internal class Students
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Boolean Gender { get; set; }
    public DateTime DoB { get; set; }
    public Double Score { get; set; }

    public override string ToString()
    {
        return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Gender)}={(Gender== true?"Male":"Female")}, {nameof(DoB)}={DoB.ToString("dd/MM/yyyy")}, {nameof(Score)}={Score.ToString("F1", CultureInfo.CurrentCulture)}}}";
    }
}
