using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEncapsulation;
internal class SunFlower : Plant
{
    static void Main(string[] args)
    {
        Plant sf = new();
        sf.Public();
        sf.Internal();
        sf.ProtectedInternal();

        SunFlower s = new();
        s.Internal();
        s.ProtectedInternal();
        s.Internal();
        s.Public();
        s.PrivateProtected();
    }
}
