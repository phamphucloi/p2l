using UseTyple;
using UseTyple.Helper;

while (true)
{
Console.WriteLine("Nhập lựa chọn : ");
int choose = Validate<int>.CheckVal();
switch (choose)
{
    case 1:
        {
            Console.WriteLine("Nhập n : ");
            int n = Validate<int>.CheckVal();

            for (int i = 1; i <= n; i++)
            {
                List<int, string, string> l = new();
                Console.WriteLine("Nhập id : ");
                int id = Validate<int>.CheckVal();

                Console.WriteLine("Nhập name : ");
                string name = Validate<string>.CheckVal();

                Console.WriteLine("Nhập address : ");
                string addr = Validate<string>.CheckVal();
                l.Stu(id, name, addr);
            }
        }
        break;
    case 2:
        {
            List<int, string, string>.Print();
        }
        break;
}
}