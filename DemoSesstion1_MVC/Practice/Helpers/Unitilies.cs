namespace Practice.Helpers;

public class Unitilies
{
    public static string ProcessImage(string file)
    {
        var getDotPositionOnString = file.LastIndexOf('.');
        var cutDotOnString = file.Substring(getDotPositionOnString);
        var gui = Guid.NewGuid().ToString().Replace("-", "");
        return gui + cutDotOnString;
    }

    public static string GetTypeFile(string file)
    {
        var getDotPositionOnString = file.LastIndexOf('.');
        var cutDotOnString = file.Substring(getDotPositionOnString);
        return cutDotOnString;
    }
}
