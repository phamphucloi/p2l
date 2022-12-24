using OOPPolymorphismInterface;

File1 f1 = new();

f1.WriteBinaryFile();
f1.WriteTextFile();
f1.ReadFile();

((IBinaryFile)f1).ShowInfo();

(f1 as IBinaryFile).ShowInfo();

//File2 f2 = new();
//f2.WriteBinaryFile();
//f2.WriteTextFile();

Console.WriteLine("Lan 1");
ITextFIle itext = new File1();
itext.ReadFile();

//Console.WriteLine("Lan 2");
//itext = new File2();
//itext.ReadFile();