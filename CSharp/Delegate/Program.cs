using Delegate;

Mathems ma = new();
ma.Sub(1, 2);

Mathems.Multi(5,6);

new Mathems().Dev(10, 2);

//hiện tượng sụp đổ => nếu Mathems có lỗi thì nó cũng kéo theo program bị lỗi

//delegate lấy thằng Mathems ra chạy cho Program 

Test t = new Mathems().Sum;//delegate không chạy được static

t(1, 5);//dù có lỗi j đi nữa thì class vẫn chạy bình thường. || safe thread = luồng an toàn