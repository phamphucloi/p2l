
//string? a = null;

//Console.WriteLine(a is not null ? a.Length : "Khoong cos gias trij naof hetes");


//? nullable value type
// -------------------> string? name = "123";

// operator !=
// -------------------> int? l = name?.Length;


//?? operator ==
//int? le = name?.Length ?? 0;
// -------------------> Console.WriteLine(le);


int a = Random.Shared.Next(0,9);
int b = Random.Shared.Next(0,9);

Console.WriteLine($"{nameof(a)} = {a}, {nameof(b)}={b}");

Console.WriteLine("Enter an mark : ");

string c;
c = Console.ReadLine();

Console.WriteLine(
    c switch
    {
        "+"            => a + b,
        "-" when a > b => a - b,
        "*" when b > 0 => a * b,
        "/"            => a / b,
        _              => "Get out,..."
    }
    );