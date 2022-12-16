using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Baitap;
public class Sinh
{ 
   public static void Enter(string i)
    {
        var rg = new Regex("^[0-9]+$");

        if (rg.IsMatch(i))
        {
            int result = Convert.ToInt16(i);
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Must be a number");
        }
    }

}
