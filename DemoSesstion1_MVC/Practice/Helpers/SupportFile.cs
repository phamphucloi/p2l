namespace Practice.Helpers;

public class SupportFile
{
    public static string ForFile(string file)
    {
        var findLastIndexOfDot = file.LastIndexOf(".");
        var cutDot = file.Substring(findLastIndexOfDot);
        var gui = Guid.NewGuid().ToString().Replace("-","");
        return gui + cutDot;
    }
}
