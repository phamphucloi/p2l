using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppGro;
internal class Validation
{
    public static string CheckRegex(string regex, string mess)
    {
        Console.WriteLine(mess);

        while (true)
        {
            string input = Console.ReadLine();

            var rg = new Regex(regex);
            var ma = rg.Match(input);

            if(ma.Success)
            {
                return input;
                Console.WriteLine("Successfully");
            }
            else
            {
                Console.WriteLine("Error!!!");
                Console.Write("Please enter again : ");
            }
        }
    }
}
