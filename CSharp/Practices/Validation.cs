using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practices;
internal class Validation
{
    public static String CheckRegex(string re, string mess)
    {

        Console.Write(mess);

        while (true)
        {
        string input = Console.ReadLine();
        Regex rg = new Regex(re);
         //Match match = rg.Match(input);
            if (rg.IsMatch(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine(mess);
            }
        }
    }
}
