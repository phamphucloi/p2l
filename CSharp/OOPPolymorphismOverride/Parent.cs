using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPolymorphismOverride;
internal class Parent
{
    public void Show() => Console.WriteLine("Parent show");

    public virtual void Display() => Console.WriteLine("Parent display");
}
