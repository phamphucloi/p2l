double a = 0.1;

double b = 0.2;

//Console.WriteLine((a+b==0.3)?"Giỏi":"Ngu");

float c = 0.6f;


decimal d = 0.8m;
decimal e = 0.2m;
Console.WriteLine((d + e == 1m) ? "Giỏi" : "Ngu");

//?: => ternary operator
string? name = null;
Nullable<int> i = null;

bool? check = null;

// ? nullable value type

Nullable<int> length = name is not null ? name.Length : null;

if (a is 10)
{

}

// null-conditional operator ?
//  tương tự dấu !=, name mà khác null trả về vế phải.
int? lengths = name?.Length;

// ?? null-codlescing operator 
// tương tự như dấu ==

//name bằng null thì trả về vế sau.

int? length2 = name?.Length ?? 0;