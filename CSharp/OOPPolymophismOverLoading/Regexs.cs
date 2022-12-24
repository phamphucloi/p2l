using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOPPolymophismOverLoading;
internal class Regexs
{
    public static string CheckRegex(string regex, string mess)
    {
        Console.WriteLine(mess);

        while (true)
        {
            string input = Console.ReadLine();

            var rg = Regex.Matches(input, regex);

        }
    }
}
