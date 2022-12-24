using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OOPPolymorphismInterface;
internal interface IBinaryFile
{
    // return type, name, method
    void WriteBinaryFile();
    void ReadFile();

    //default method of interface
    void ShowInfo() => Console.WriteLine("This is binary file");
}
