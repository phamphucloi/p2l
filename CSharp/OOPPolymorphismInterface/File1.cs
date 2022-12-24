using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPolymorphismInterface;
internal class File1 : IBinaryFile, ITextFIle
{
    public void ReadFile() => Console.WriteLine("Read File");

    public void WriteBinaryFile() => Console.WriteLine("Write bynary file");

    public void WriteTextFile() => Console.WriteLine("WriteTextFile");


}
