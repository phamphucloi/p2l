using Excerise.ExtentionMethod;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excerise.Helper;
internal class Validation<T>
{
    public static T CheckReadLine()
    {
        var typeCode = Type.GetTypeCode(typeof(T));
        object obj = new();
        bool flag;
        do
        {
            flag = true;
            try
            {
                var str = Console.ReadLine();
                if (string.IsNullOrEmpty(str))
                {
                    throw new Exception("Error, null or empty");

                }

                switch (typeCode)
                {
                    case TypeCode.String: obj = str; break;

                    case TypeCode.Int32: obj = Convert.ToInt32(str); if ((int)obj < 0) throw new Exception("Value must be greater than zero"); break;

                    case TypeCode.Double: obj = Convert.ToDouble(str); if ((double)obj < 0) throw new Exception("Value must be greater than zero"); break;

                    case TypeCode.DateTime: var date = DateTime.TryParseExact(str, new[] {"d/M/yyyy", "d-M-yyyy"},new CultureInfo("vi-VN"), DateTimeStyles.None, out var t)?t:throw new Exception("DateTime wrong"); obj = date.Add(DateTime.Now.TimeOfDay); break;
                    case TypeCode.Char: obj = Convert.ToChar(str); if (!obj.In('y', 'n')) throw new Exception("Error, must be y or n"); break;
                    default: obj = null; break;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.GetType()}:{e.Message}, enter again");
                flag = false;
            }
        } while (!flag);
        return (T)obj;
    }
}
