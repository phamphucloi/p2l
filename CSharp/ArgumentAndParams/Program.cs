using ArgumentAndParams;

//pure OOP
//use var
//var argu = new ArgumentClass();

//target-type
ArgumentClass argu = new();

//named argument
argu.Display(1, 2, 3);

argu.Display(a: 4, b: 5, c: 5);

argu.Display(a: 4, c: 5, b: 5);

argu.Show(10,12);

argu.Show(b:10, a: 12, c:4);

argu.Show(a: 12, c: 4);