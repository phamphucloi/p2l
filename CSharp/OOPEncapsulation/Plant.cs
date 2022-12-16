using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEncapsulation;
public class Plant
{
    //encapsulation the hien at 2 places
    //a) access modify b) property

    //a) access modify

    private void Private() => Console.WriteLine("Private");
    protected void Protected() => Console.WriteLine("Protected");
    internal void Internal() => Console.WriteLine("Internal");
    private protected void PrivateProtected() => Console.WriteLine("Private protected");
    protected internal void ProtectedInternal() => Console.WriteLine("Protected Internal");
    public void Public() => Console.WriteLine("Public");
}
