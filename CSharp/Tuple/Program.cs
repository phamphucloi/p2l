using UsingTuple;

Person per = new()
{
    Id = 1,
    FName = "Phạm",
    LName = "Lợi"
};

Console.WriteLine(per.Id);
Console.WriteLine(per.FName);

//use value tuple not need class (struct)

ValueTuple<int, string, string> t1 = (1, "Phạm","Lợi");
Console.WriteLine(t1.Item1);
Console.WriteLine(t1.Item2);
Console.WriteLine(t1.Item3);

//news
(int, string, string) t2 = (1,"123","443");
Console.WriteLine(t2.Item3);

var t3 = (1, "2", "3");
Console.WriteLine(t3.Item1);

var t4 = (1,2);



//net core use name convert item1, item2, item3,...

(int id, string fname, string lname) t5 = (1, "123","43");
Console.WriteLine(t5.lname);

//có thể thay đổi giá trị
//or use name before
var t6 = (id: 1, fname: "lợi", lname: "123");
Console.WriteLine(t6.id);
Console.WriteLine(t6.fname);

//không thể thay đổi giá trị
//not tuple => anonymous type
var t7 = new { id=1,name="lợi",gen=true };
Console.WriteLine(t7.id);
Console.WriteLine(t7.gen);
