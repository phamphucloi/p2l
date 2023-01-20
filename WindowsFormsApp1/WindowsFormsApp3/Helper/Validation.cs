using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3.Helper
{
    internal class Validation<T>
    {
        public static T CheckRegex()
        {
            bool flag = true;
            TypeCode type = Type.GetTypeCode(typeof(T));
            object ob = new object();

            var str = Console.ReadLine();
            while (flag)
            {
                try
                {
                    switch (type)
                    {
                        case TypeCode.String: ob = str; break;
                        case TypeCode.Boolean: ob = Convert.ToBoolean(str); flag = false; break;
                        case TypeCode.Int16: ob = Convert.ToInt16(str); if ((int)ob < 0) throw new Exception("Không đc nhỏ hơn 0"); break;
                        default: flag = true; break;
                    }
                }
                catch(Exception ev) 
                {
                    MessageBox.Show($"{ev.Message}, Please Enter again : ");
                }
            }
            return (T)ob;
        }
    }
}
