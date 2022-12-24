namespace PhamPhucLoi_C2109I1;
internal class ListStudents
{
    private List<Student> List = new();

    public void InsertStudent()
    {
        Student stu = new()
        {
            //Id = int.Parse(Validation.CheckRegex(Regexs.ID, "Please enter id : ")),
            //Name = Validation.CheckRegex(Regexs.NAME, "Please enter your name : "),
            Gender = Validation.CheckRegex(Regexs.GENDER, "==========Press 0 is male or 1 is female==========\nPlease enter gender : ")=="1"?true:false,
            //DoB = DateOnly.Parse(Validation.CheckRegex(Regexs.DOB, "Please enter day of birth : ")),
        };
        List.Add(stu);
        List.Distinct();
        Console.WriteLine("\n===============Insert successfully===============\n");
    }

    public void UpdateProducts(int id)
    {
        var update = List.Where(stu=>stu.Id==id).ToList();
        if (update.Count <= 0)
        {
            Console.WriteLine("Not exists id is : " + id);
            return;
        }
        //update.First().Name = Validation.CheckRegex(Regexs.NAME, "Please enter your name : ");
        update.First().Gender = Validation.CheckRegex(Regexs.GENDER, "please enter gender : ")=="1" ? true : false;
        //update.First().DoB = DateOnly.Parse(Validation.CheckRegex(Regexs.DOB, "Please enter day of birth : "));
        Console.WriteLine("\n===============Update Successfully===============\n");
    }

    public void SelectProducts()
    {
        if (List.Count <= 0)
        {
            Console.WriteLine("No data");
            return;
        }
        List.ForEach(Console.WriteLine);
    }

    public void DeleteProducts(int id)
    {
        if (List.Count <= 0)
        {
            Console.WriteLine("Not exists id is : " + id);
            return;
        }
        List.RemoveAll(stu => stu.Id == id);
        Console.WriteLine("\n===============Delete Successfully===============\n");
    }

    public void SearchStudents(string name)
    {
        if (List.Count <= 0)
        {
            Console.WriteLine("Not exists name is : " + name);
            return;
        }
        List.Where(stu => stu.Name == name)
        .ToList()
        .ForEach(Console.WriteLine);
    }

    public void OrderById()
    {
        if (List.Count <= 0)
        {
            Console.WriteLine("No Data");
            return;
        }
        List.OrderBy(stu => stu.Id).ToList().ForEach(Console.WriteLine);
        Console.WriteLine("\n===============Sort successfully===============\n");
    }

}
