using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGro;
internal class Menu
{
    public void ShowMenu()
    {
        ListPro list = new();

        bool flag = true;
        while (flag)
        {
            Console.WriteLine("Choose 1 : to insert product in stock");
            Console.WriteLine("Choose 2 : to print all products in stock");
            Console.WriteLine("chose 3 : to delete");
            Console.WriteLine("choose 4 : to update");
            Console.WriteLine("choose 5 : sort product");
            var choose = int.Parse(Validation.CheckRegex(Regexx.ID, "Enter your choose : "));

            switch(choose)
            {
                case 1:  list.InsertProduct(); break;
                case 2: list.Select(); break;
                case 3:
                    {
                        int id = int.Parse(Validation.CheckRegex(Regexx.ID, "Enter id to delete : "));

                        list.Delete(id);
                        Console.WriteLine("Delete Successfully");
                    }
                    break;
                case 4:
                    {
                        int id = int.Parse(Validation.CheckRegex(Regexx.ID, "Enter id to update : "));
                        list.Update(id);
                        Console.WriteLine("Update Successfully");
                    }
                    break;

                case 5:
                    {
                  
                        Console.WriteLine("Sort Successfully");
                    }   
                    break;
                default: flag = false; break;
            }
        }

    }


        

}
