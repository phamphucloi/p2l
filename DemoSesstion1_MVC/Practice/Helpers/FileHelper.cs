namespace Practice.Helpers;

public class FileHelper
{
    public static string generationImage(string fileName)
    {
        var lastIndex = fileName.LastIndexOf('.');
        var ext = fileName.Substring(lastIndex);
        var gui = Guid.NewGuid().ToString().Replace("-", "");
        return gui + ext;
    }

}
