namespace NewExcercise.Menu;
internal class Menu
{
    public static void Option()
    {
        bool flag = true;

        while (flag)
        {
            Console.WriteLine("choose 0 : End Program");
            Console.WriteLine("choose 1 : insert students in list");
            Console.WriteLine("choose 2 : display all students");
            Console.WriteLine("choose 3 : delete a student in list");
            Console.WriteLine("choose 4 : update a student in list");
            Console.WriteLine("===================*****==================");
            Console.Write("Please choose option : => ");
            int option = Validate<int>.CheckRegex();


            switch (option)
            {
                case 0: Console.WriteLine("======End program======="); flag = false; break;

                case 1: StudentDAL.AddStudents();  break;

                case 2: StudentDAL.PrintStudents(); break;

                case 3:
                    {
                        if (StudentDAL.List.Count <= 0)
                        {
                            Console.WriteLine("\n==============No data===============\n");
                            break;
                        }
                        Console.WriteLine("Enter id to delete : "); 
                        int id = Validate<int>.CheckRegex(); 
                        StudentDAL.DeleteStudent(id);
                        Console.WriteLine("==========Delete Successfully==========");
                    }
                        break;
                case 4:
                    {
                        if (StudentDAL.List.Count <= 0)
                        {
                            Console.WriteLine("\n==============No data===============\n");
                            break;
                        }
                        Console.WriteLine("Enter id to update : ");
                        int id = Validate<int>.CheckRegex(); 
                        StudentDAL.UpdateStudents(id);
                        Console.WriteLine("==========Update Successfully==========");
                    }
                        break;
                case 5:
                    {
                        if (StudentDAL.List.Count <= 0)
                        {
                            Console.WriteLine("\n==============No data===============\n");
                            break;
                        }
                        StudentDAL.SortById();
                    }
                    break;
                case 6:
                    {
                        Console.WriteLine("Enter students : ");
                        var name = Validate<string>.CheckRegex();
                        StudentDAL.SearchStudents(name);
                    }
                    break;
                default: Console.WriteLine($"Not exists option is : {option} \n"); break;
            }
        }
    }
}
