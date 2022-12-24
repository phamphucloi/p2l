namespace PhamPhucLoi_C2109I1;
internal class Menu
{
    public static void ShowMenu()
    {
        ListStudents list = new();

        bool check = true;

        while (check)
        {
            Console.WriteLine("Choose 1 : Insert students in list.");
            Console.WriteLine("Choose 2 : Update a student in list.");
            Console.WriteLine("Choose 4 : Delete a student in list.");
            Console.WriteLine("Choose 3 : Print students in list.");
            Console.WriteLine("Choose 5 : Find students in list.");
            Console.WriteLine("Choose 6 : Sort students in list.");

            var choose = int.Parse(Validation.CheckRegex(Regexs.ID,"Please enter your option :  "));

            switch (choose)
            {
                case 1: list.InsertStudent(); break;
                case 2:
                    {
                        int id = int.Parse(Validation.CheckRegex(Regexs.ID, "Please enter id to update : "));
                        list.UpdateProducts(id);
                    }
                    break;
                case 3: list.SelectProducts(); break;
                case 4:
                    {
                        int id = int.Parse(Validation.CheckRegex(Regexs.ID, "Please enter id to delete : "));
                        list.DeleteProducts(id);
                    }
                    break;
                case 5:
                    {
                        string name = Validation.CheckRegex(Regexs.NAME,"Please enter name to search : ");
                        list.SearchStudents(name);
                    }
                    break;
                case 6: list.OrderById(); break;
                default: check = false; Console.WriteLine("\n=============End Program============="); break;
            }
        }
    }
}
