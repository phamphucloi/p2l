namespace PhamPhucLoi_C2109I1;
internal class Validation
{
    public static string CheckRegex(string regex, string mess)
    {
        Console.Write(mess);
        while (true)
        {
            string input = Console.ReadLine();
            var pa = new Regex(regex);
            var ma = pa.Match(input);
            if (ma.Success)
            {
                return input;
            }
            else
            {
                Console.WriteLine("Invalid");
                Console.Write("Please enter again : ");
            }
        }
    }
}
