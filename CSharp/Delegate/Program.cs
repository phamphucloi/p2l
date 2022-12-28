using Delegate;

//c1
Mathems ma = new();
ma.Sub(1, 2);


//c2
new Mathems().Dev(10, 2);

//c3
Mathems.Multi(5,6);
//hiện tượng sụp đổ => nếu Mathems có lỗi thì nó cũng kéo theo program bị lỗi

//delegate lấy thằng Mathems ra chạy cho Program 


//delegate
Test t = new Mathems().Sum;//delegate không chạy được static
t += new Mathems().Sub;
t(5, 9);//dù có lỗi j đi nữa thì class vẫn chạy bình thường. || safe thread = luồng an toàn