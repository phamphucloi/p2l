namespace C2109I1_Pham_Phuc_Loi.Helper;
internal class Validation<T>
{
    public static T CheckRegex(string mess)
    {
        Console.Write(mess);
        bool flag = true;
        object ob = new();
        var type = Type.GetTypeCode(typeof(T));

        while (flag)
        {
            try
            {
                string str = Console.ReadLine();
                if (string.IsNullOrEmpty(str)) throw new Exception("Not null");
                switch (type)
                {
                    case TypeCode.String: ob = str; flag = false; break;

                    case TypeCode.Int32: ob = Convert.ToInt32(str); if ((int)ob < 0) throw new Exception("must be largest zero ( > 0)"); flag = false; break;

                    case TypeCode.Boolean:
                        {
                                switch (str)
                                {
                                    case "y": ob = true; flag = false; break;

                                    case "n": ob = false; flag = false; break;

                                    default: flag = true; throw new Exception("'y' or 'n'");
                                }
                        }
                        break;

                    case TypeCode.DateTime: DateTime date = DateTime.TryParseExact(str, new[] {"d-M-yyyy", "d/M/yyyy"},new CultureInfo("vi-VN"),DateTimeStyles.None,out var day)?day:throw new Exception("dd-MM-yyyy"); ob = date; flag = false; break;

                    case TypeCode.Double: ob = Convert.ToDouble(str); if((double)ob < 0) throw new Exception("Sroce more than zero"); flag = false; break;
                    default: ob = null; flag = true; break;
                }
            }
            catch (Exception e)
            {
                Console.Write($"{e.GetType} - {e.Message} \n{mess} ");
                flag = true;
            }
        }
        return (T)ob;
    }
}
