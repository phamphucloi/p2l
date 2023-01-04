
using Study;


bool flag = true;

while (flag)
{
    Console.WriteLine("Nhập lựa chọn : ");
    int chon = Convert.ToInt32(Console.ReadLine());
    switch (chon)
    {
        case 1:
            {
                Console.WriteLine("Nhập n : ");
                int n = Convert.ToInt32(Console.ReadLine());

                for (int i = 1; i <= n;i++)
                {
                    Console.WriteLine("Nhập id : ");
                    int a = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Nhập name : ");
                    string b = Console.ReadLine();

                    Console.WriteLine("Nhập gender : ");
                    bool c = (Console.ReadLine())=="1"?true:false;
                    List<int, string, bool>.Insert(a,b,c);
                }

            }
            break;
        case 2: 
            {
                List<int,string,bool>.Print();
            } 
            break;
    }
}
