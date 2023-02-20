using System.Globalization;

namespace DemoSesstion1_MVC.Helpers;

public class FileHelper
{
    public static string generateFileName(string fileName)
    {
        var lastIndex = fileName.LastIndexOf('.');
        var ext = fileName.Substring(lastIndex);
        var gui = Guid.NewGuid().ToString().Replace("-", "");

        return gui + ext;
    }
}
