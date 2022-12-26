using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practices;
internal class Menu
{
    public static void ShowMenu()
    {
        ListStudent list = new();

        Boolean flag = true;
        while (flag)
        {
            Console.WriteLine("chọn 1 insert");
            Console.WriteLine("chọn 2 delete");
            Console.WriteLine("chọn 3 update");
            Console.WriteLine("chọn 4 in");
            Console.WriteLine("chọn 5 sort");
            Console.WriteLine("chọn 6 search");
            Console.WriteLine();
            Console.WriteLine("Chọn option : ");
        int option = Convert.ToInt32(Console.ReadLine());
        switch (option)
            {
                case 1: list.InsertStudent(); break;
                case 2:
                    {
                        int id = Convert.ToInt32(Console.ReadLine());
                        list.DeleteStudent(id);
                    }
                    break;
                case 3:
                    {
                        int id = Convert.ToInt32(Console.ReadLine());
                        list.UpdateStudent(id);
                    }
                    break;
                case 4: list.SelectAllStudents(); break;
                case 5: list.SortStudentById(); break;
                case 6:
                    {
                        string name = Console.ReadLine();
                        list.SearchStudentsByName(name);
                    }
                    break;
                default: flag = false; break;
            }
        }
    }
}
