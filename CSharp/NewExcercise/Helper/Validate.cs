namespace NewExcercise.Helper;
internal class Validate<T>
{
    public static T CheckRegex()
    {
        var type = Type.GetTypeCode(typeof(T));
        bool flag;
        object obj=new();

        do
        {
            flag = true;
            try
            {
                string str = Console.ReadLine();
                if (string.IsNullOrEmpty(str))
                {
                    throw new Exception("Not null");
                }

                switch (type)
                {
                    case TypeCode.String: obj = str; break;
                    case TypeCode.Int32: obj = Convert.ToInt32(str); if ((int)obj < 0) throw new Exception("Id must be largest 0 (Id>0)"); break;
                    case TypeCode.Double: obj = Convert.ToDouble(str); if ((double)obj < 0) throw new Exception("Score must be largest 0 (Score>=0)"); break;
                    case TypeCode.DateTime: var date = DateTime.TryParseExact(str, new[] { "d/M/yyyy","d/M/yyyy" },new CultureInfo("vi-VN"),DateTimeStyles.None,out var dob)?dob:throw new Exception("Format : dd/mm/yyyy"); obj = date; date.Add(DateTime.Now.TimeOfDay); break;
                    case TypeCode.Boolean: obj = Convert.ToBoolean(str); break;
                    default: obj = null; break;
                }
            }catch (Exception e)
            {
                Console.WriteLine($"{e.GetType}:{e.Message}, please enter again : ");
                flag = false;
            }
        } while (!flag);
        return (T)obj;
    }
}
