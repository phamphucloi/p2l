using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClass;
internal class Class2<T,D>
{
    public T Name { get; set; }
    public D Description { get; set; }

    public void Show() => Console.WriteLine($"{nameof(Name)}={Name} :::: {nameof(Description)}={Description}");
}
