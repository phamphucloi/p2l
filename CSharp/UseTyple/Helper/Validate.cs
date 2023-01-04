using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseTyple.Helper;
internal class Validate<T>
{
    public static T CheckVal()
    {
        var type = Type.GetTypeCode(typeof(T));
        object ob = new();
        var flag = true;


        while (flag)
        {
            try
            {
                string str = Console.ReadLine();
                switch (type)
                {
                    case TypeCode.Int32: ob = Convert.ToInt32(str); flag = false; break;

                    case TypeCode.String: ob = str; flag = false; break;
                }
            }catch(Exception e)
            {
                Console.WriteLine("Nhập lại : ");
                flag = true;
            }
        }
        return (T)ob;
    } 
}
