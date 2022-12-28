namespace C2109I1_Pham_Phuc_Loi.Menu;
internal class ShowMenu
{
    public static void Option()
    {
        bool flag = true;

        ListStudents.InsertStudent();

        while (flag)
        {
            Console.WriteLine("Choose 0 : to exists program.");
            Console.WriteLine("Choose 1 : to insert.");
            Console.WriteLine("Choose 2 : to delete.");
            Console.WriteLine("Choose 3 : to update.");
            Console.WriteLine("Choose 4 : to print all students.");
            Console.WriteLine("Choose 5 : to sort by id.");
            Console.WriteLine("Choose 6 : to search by name.");
            Console.WriteLine("Choose 7 : to update a field in list.");

            int choose = Validation<int>.CheckRegex("Choose your option : ");

            Console.WriteLine();

            switch (choose)
            {
                case 0: Console.WriteLine("======***End***Program***======"); flag = false; break;
                case 1: ListStudents.InsertStudent(); break;

                case 2:
                    {
                        int id = Validation<int>.CheckRegex("Enter id to remove student from list : ");
                        ListStudents.DeleteStudent(id);
                    }
                    break;
                case 3:
                    {
                        int id = Validation<int>.CheckRegex("Enter id to update student from list : ");
                        ListStudents.UpdateStudent(id);
                    } 
                    break;
                case 4:
                    {
                        ListStudents.PrintStudent();
                    }
                    break;
                case 5:
                    {
                        ListStudents.SortById();
                    }
                    break;

                case 6:
                    {
                        string name = Validation<string>.CheckRegex("Enter name : ");
                        ListStudents.SearchByName(name);
                    }
                    break;
                case 7:
                    {
                        int id = Validation<int>.CheckRegex("Enter id to update: ");
                        ListStudents.UpdateAFields(id);
                    }
                    break;
                    default: flag = true; Console.WriteLine($"=========== Not exists option : {choose} ===========\n"); break;

            }
        }
    }

    public static void MenuUpdate(int id)
    {

        var updateAfields = ListStudents.List.Where(stu => stu.Id == id);

        bool flag = true;

        while (flag)
        {
            Console.WriteLine("Choose 0 : to Exists.");
            Console.WriteLine("Choose 1 : to update Name.");
            Console.WriteLine("Choose 2 : to update Gender.");
            Console.WriteLine("Choose 3 : to update Day of Birth.");
            Console.WriteLine("Choose 4 : to update Score.");
            int choose = Validation<int>.CheckRegex("Enter a number : ");

            switch (choose)
            {
                case 0: flag = false; break;
                case 1: updateAfields.First().Name = Validation<string>.CheckRegex("Enter name : "); break;

                case 2: updateAfields.First().Gender = Validation<Boolean>.CheckRegex("Enter gender : "); break;

                case 3: updateAfields.First().DoB = Validation<DateTime>.CheckRegex("Pattern date (dd-MM-yyyy || dd/MM/yyyy) \nEnter day of birth :  "); break;

                case 4: updateAfields.First().Score = Validation<Double>.CheckRegex("Enter score :"); break;

                default: flag = true; break;
            }
        }
    }

}
