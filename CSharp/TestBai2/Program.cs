using TestBai2;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

int a = 10;
int b = 20;

Ref.Reff(ref a,ref b);
Console.WriteLine($"Lần 1 : {nameof(a)}={a} ; {nameof(b)}={b}");

