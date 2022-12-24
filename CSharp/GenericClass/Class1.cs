using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClass; //tạo 1 class dùng chung cho tất cả | đều kiện là các class phải có chung field
internal class Class1<T>
{
    public T Field { get; set; }

    public void Show() => Console.WriteLine(Field);
}
