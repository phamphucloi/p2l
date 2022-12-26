using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practices;
internal class Regexs
{
    public static string ID = "[0-9]+";

    public static string NAME = "[a-z]+";

    public static string GENDER = "[0-1]";

    public static string BIRTHDAY = "^[0-9]{1,2}\\/[0-9]{1,2}\\/[0-9]{4}$";
}
