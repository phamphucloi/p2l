using ListAndLINQ;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

List<Student> list = new()
{
    new Student()
    {
        RollNum=1,FullName="Phạm Phúc Lợi",Section="area 1",HotelNum=1
    },

    new Student()
    {
        RollNum=2,FullName="Phạm Phúc Lợi 1",Section="area 2",HotelNum=2
    },

    new Student()
    {
        RollNum=3,FullName="Phạm Phúc Lợi 2",Section="area 3",HotelNum=3
    },

    new Student()
    {
        RollNum=4,FullName="Phạm Phúc Lợi 3",Section="area 4",HotelNum=4
    },

        new Student()
    {
        RollNum=5,FullName="Phạm Phúc Lợi 4",Section="area 5",HotelNum=5
    }
};

Stopwatch sw = new();
sw.Restart();


foreach (var l in list)
{
    Console.WriteLine(l);
}

Console.WriteLine($"foreach time : {sw.ElapsedMilliseconds}");
sw.Restart();

//==============================================================
IEnumerator<Student> stu = list.GetEnumerator();

while (stu.MoveNext())
{
    Console.WriteLine(stu.Current);
}

Console.WriteLine($"foreach time : {sw.ElapsedMilliseconds}");
sw.Restart();
//tất cả các dạng của collection đều có mẫu duyệt qua dữ liệu mà không cần for hay foreach
//ienumarator

//LinQ => language Intergrated query;

//linQ to object (list)
//linQ to sql
//linQ to JSon, XML
//Parallel linQ => plinQ

//select from where group by having order by
//from where group by having order by => select

//=====LINQ to Object=======
//style(1) theo trường phái SQL : Query Syntax, dễ học, dễ hiểu
//style(2) theo trường phái lamda : Method Syntax, khó học, rất khó để hiểu

//liệt kê tất cả sinh viên với mã sinh viên phải lớn hơn 2;
foreach(var su in list)
{
    if(su.RollNum > 2)
    {
        Console.WriteLine("=============" + su + "=============");
    }
}

//style 1:
var lstu = (from s in list where s.RollNum > 2 select s);
//tìm tổng số sinh viên trong list
Console.WriteLine("Có tất cả : " +lstu);


foreach (var st in lstu)
{
    Console.WriteLine("--->" + st + "<---");
}

//foreach (var st in (IEnumerable<Student>?)(from s in list
//                                           where s.RollNum > 2
//                                           select s))
//{
//    Console.WriteLine("--->" + st + "<---");
//}

//style 2: Method Syntax

//====================================================================
//Console.WriteLine("============================================");
//var listStu = list.Where(stu=>stu.RollNum > 2);
//foreach (var st in listStu)
//{
//    Console.WriteLine("========>" + st + "<========");
//}
//====================================================================

//var listSt = list.Select(stu => stu).Where(stu => stu.RollNum > 2);//sai cú pháp

//các methods có sẵn trong list

//======================================================================================================
//list.ForEach(Console.WriteLine);

//Console.WriteLine("==========================");

//list.ForEach(stu=>Console.WriteLine(stu.RollNum > 2));

//Console.WriteLine("==========================");

//list.ForEach(stu =>
//                    {
//                        if(stu.RollNum > 2)
//                        {
//                            Console.WriteLine(stu);
//                        }
//                    }
//);

//kết hợp lamda với list
//list.ForEach(stu => stu.RollNum > 2)

//list.Where(stu => stu.RollNum > 2)
//    .ToList()
//    .ForEach(Console.WriteLine);

//var r = from stud in list
//        where stud.RollNum > 2
//        select new
//        {
//            stud.RollNum,
//            stud.FullName
//        };//anonymus type;
//r.ToList().ForEach(Console.WriteLine);

//var r = from stud in list
//        where stud.RollNum > 2
//        select new
//        {
//            StudentDetails = $"{stud.RollNum} : {stud.FullName}",
//            StudentRoom = $"{stud.Section} : {stud.HotelNum}"
//        };//anonymus type;
//r.ToList().ForEach(Console.WriteLine);

//method syntax

//list.Select(
//    stud => new
//    {
//        StudentDetails = $"{stud.RollNum} : {stud.FullName}",
//        StudentRoom = $"{stud.Section} : {stud.HotelNum}"
//    }).ToList().ForEach(Console.WriteLine);

foreach(var s in list)
{
    Console.WriteLine(s);
}

IEnumerator enu = list.GetEnumerator();
while (enu.MoveNext())
{

}

//while linq

var t = from stude in list select stude;

//lần đầu tiên thực thi trên server và trả về bộ nhớ

//select * from list where  rollnum > 2
IEnumerable<Student> i = from studen in list select studen;

i = i.Take(2);
//là vào bộ nhớ loại bỏ chỉ lấy 2 dòng đầu tiên

//linq to sql
//select * from list where  rollnum > 2
IQueryable<Student> u = from student in list.AsQueryable() select student;
//select top(2)* from list where  rollnum > 2
//sẽ chạy lên server lần nữa.
u = u.Take(2);

Console.WriteLine("============================================");
var k = from stui in list where stui.RollNum > 2 select stui;
k.ToList().ForEach(Console.WriteLine);

k.ToList().OrderDescending();

list.Order();

Console.WriteLine("========================================================123");
var obj = from Stu in list
          orderby Stu.RollNum descending
          select Stu;
obj.ToList().ForEach(Console.WriteLine);

Console.WriteLine("----------------------------------------------------");
var obj2 = list.OrderByDescending(stu=>stu.Section);
obj2.ToList().ForEach(Console.WriteLine);

Console.WriteLine("----------------------------------------------------");
var obj3 = list.OrderByDescending(stu => stu.Section).OrderBy(stu=>stu.HotelNum);
obj3.ToList().ForEach(Console.WriteLine);

Console.WriteLine("----------------------------------------------------");
var obj4 = list.OrderByDescending(stu => stu.Section).ThenBy(stu => stu.HotelNum);
obj4.ToList().ForEach(Console.WriteLine);

Console.WriteLine("----------------------------------------------------");
var obj5 = list.Where(stu=>stu.RollNum > 2).OrderByDescending(stu => stu.Section).ThenBy(stu => stu.HotelNum);
obj5.ToList().ForEach(Console.WriteLine);
