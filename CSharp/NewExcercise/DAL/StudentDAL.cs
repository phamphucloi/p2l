namespace NewExcercise.DAL;
internal static class StudentDAL
{
    public static List<Students> List { get; set; } = new();

    public static void AddStudents()
    {
        Console.Write("Enter the number of students : ");
        int n = Validate<int>.CheckRegex();

        for (int i = 0; i < n; i++)
        {
            int count = i;
            Students stu = new();
            Console.Write($"\nEnter students is : {++count} \n");

            stu.Id = count;
            Console.WriteLine($"{nameof(stu.Id)} students = {stu.Id}");

            Console.Write("Enter name students : ");
            stu.Name = Validate<string>.CheckRegex();

            Console.Write("Enter gender students : ");
            stu.Gender = Validate<bool>.CheckRegex();

            Console.Write("Enter day of birth :    ");
            stu.DoB =  Validate<DateTime>.CheckRegex();

            Console.Write("Enter score :    ");
            stu.Score= Validate<Double>.CheckRegex();

            List.Add(stu);
            Console.WriteLine("======================Insert successfull==================");

        }
    }

    public static void PrintStudents()
    {
        for (int i = 1; i <= 30; i++)
        {
            Console.Write("=");
        }
        Console.WriteLine();
        List.ForEach(Console.WriteLine);
        for (int i = 1; i <= 30 ; i++)
        {
            Console.Write("=");
        }
        Console.WriteLine();
    }

    public static void DeleteStudent(int id)
    {
        if (List.Where(stu => stu.Id == id).ToList().Count <= 0)
        {
            Console.WriteLine($"Not exists id is : {id} \n");
            return;
        }

        List.RemoveAll(stu=>stu.Id==id);
    }

    public static void UpdateStudents(int id)
    {
        if (List.Where(stu => stu.Id == id).ToList().Count <= 0)
        {
            Console.Write($"Not exists id is : {id} \n");
            return;
        }

        var update = List.Where(stu => stu.Id == id);


        Console.Write("Enter name students : ");
        update.First().Name = Validate<string>.CheckRegex();

        Console.Write("True is male || False is female \n Enter gender students : ");
        update.First().Gender= Validate<bool>.CheckRegex();

        Console.Write("Pattern date (dd/MM/yyyy) \n Enter day of birth students : ");
        update.First().DoB = Validate<DateTime>.CheckRegex();

        Console.Write("Enter score students : ");
        update.First().Score= Validate<Double>.CheckRegex();
    }

    public static void SortById()
    {
        List.OrderDescending().ToList().ForEach(Console.WriteLine);
    }

    public static bool SearchStudents(string name, params string[] values)
    {
        return values.Contains(name);
    }
}
