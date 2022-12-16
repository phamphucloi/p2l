using OOPEncapsulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEncapsulationCont;
internal class Weed : Plant
{
    static void Main(string[] args)
    {
        Weed w = new();

        w.Public();
        w.ProtectedInternal();
        w.Protected();
    }
}
