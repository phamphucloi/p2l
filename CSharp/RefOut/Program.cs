using RefOut;

int a = 10;
int b = 11;

UseRefOut.ChangeNum(ref a, ref b);
Console.WriteLine($"Change number {nameof(a)}={a}, {nameof(b)}={b}");