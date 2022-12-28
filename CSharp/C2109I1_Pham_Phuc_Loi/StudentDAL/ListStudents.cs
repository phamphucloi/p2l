namespace C2109I1_Pham_Phuc_Loi.StudentDAL;
internal class ListStudents
{
    public static List<Students> List { get; set; } = new();

    public static void InsertStudent()
    {
        Console.WriteLine("=============================***You are at INSERT***=============================\n");
        Console.Write("Enter the number of students :  ");

        int n = Convert.ToInt16(Console.ReadLine());

        for (int i = 0; i < n;i++)
        {
            int count = i;//id = 0 => count = 0 
            Students stu = new();
            foreach (var j in List)
            {
                if (j.Id==count)
                {
                    stu.Id = ++count;
                }
                else
                {
                    stu.Id = count;
                }
            }
            Console.WriteLine($"Id student is : ==={count}===");
            stu.Name = Validation<string>.CheckRegex("Enter name :  ");
            stu.Gender = Validation<Boolean>.CheckRegex("Are you male?\n'y' or 'n' -->  ");
            stu.DoB = Validation<DateTime>.CheckRegex("Pattern date (dd-MM-yyyy || dd/MM/yyyy) \nEnter day of birth :  ");
            stu.Score = Validation<Double>.CheckRegex("Enter score :  ");
            List.Add(stu);
        }
    }

    public static void DeleteStudent(int id)
    {
        if (List.Where(stu=>stu.Id==id).ToList().Count <=0)
        {
            Console.WriteLine($"Not exists id is : {id}\n");
            return;
        }
        Console.WriteLine("=============================***You are at DELETE***=============================\n");
        List.RemoveAll(stu=>stu.Id==id);
        Console.WriteLine("=========== Delete Successfully ============");
    }

    public static void UpdateStudent(int id)
    {
        var update = List.Where(stu => stu.Id == id);
        if (update.ToList().Count <= 0)
        {
            Console.WriteLine($"Not exists id is : {id}\n");
            return;
        }
        Console.WriteLine("=============================***You are at UPDATE***=============================\n");
        Console.WriteLine($"\nUpdating a student have id : ==={id}===\n");
        update.First().Name = Validation<string>.CheckRegex("Enter name :  ");
        update.First().Gender = Validation<Boolean>.CheckRegex("Enter gender :  ");
        update.First().DoB = Validation<DateTime>.CheckRegex("Parttern date(dd/MM/yyyy) \nEnter day of birth : ");
        update.First().Score = Validation<Double>.CheckRegex("Enter score of students : ");
        Console.WriteLine("=========== Update Successfully ============");
    }

    public static void PrintStudent()
    {
        for (int i = 1; i <= 90;i++)
        {
            Console.Write("=");
        }
        Console.WriteLine("\n");

        foreach (var i in List)
        {
            Console.WriteLine("\t==" + i + "==");
        }

        Console.WriteLine();
        for (int i = 1; i <= 90; i++)
        {
            Console.Write("=");
        }
        Console.WriteLine("\n");
    }

    public static void SortById()
    {
        List.OrderByDescending(stu=>stu.Id).ToList().ForEach(Console.WriteLine);
    }

    public static void UpdateAFields(int id)
    {
        var updateAfields = List.Where(stu => stu.Id == id);

        if (updateAfields.ToList().Count <= 0)
        {
            Console.WriteLine($"Not exists id is : {id}\n");
            return;
        }
        Console.WriteLine("=============================***You are at UPDATE A FIELDS***=============================\n");
        PrintStudent();

        ShowMenu.MenuUpdate(id);
    }

    public static void SearchByName(string name)
    {
        var search = List.Where(stu => stu.Name == name).ToList();
        if (search.Count <= 0)
        {
            Console.WriteLine($"=============================Not exists name is {name}=============================\n");
        }
        Console.WriteLine("=============================***You are at SEARCH***=============================\n");
        search.ForEach(Console.WriteLine);
    }
}
