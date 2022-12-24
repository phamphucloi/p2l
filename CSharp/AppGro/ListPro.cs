using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppGro;
internal class ListPro
{
    public List<Product> List;

    public ListPro()
    {
        this.List = new List<Product>();
    }

    public List<Product> GetProducts()
    {
        return List;
    }

    public void setProduct(List<Product> prod)
    {
        this.List = prod;
    }

    public void InsertProduct()
    {
        //var list = new List<Product>();
        Product pro = new();
        pro.AddPro();
        List.Add(pro);
        //if(List != null)
        //{
        //    Console.WriteLine(List);

        //    foreach(var i in List)
        //    {
        //        Console.WriteLine($"{nameof(i)}={i}");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("No Data");
        //}

        //list.ForEach(p => list.Add(p));
        //list.Add(pro);
        //foreach (var i in list)
        //{

        //}
    }

    int i = 0;
    public void Select()
    {
        //for (int i = 0; i < List.Count; i++)
        //{
        //    Console.WriteLine($"Id : {Product.Id} ,Name : {Product.Name}");
        //}
        List.ForEach(p=> Console.WriteLine($"Id={Product.Id}\nName={Product.Name}\nGender={((Product.Gender).Equals(0)?"Female":"Male")}"));
    }
        
    public void Delete(int id)
    {
        if (List == null)
        {
            Console.WriteLine("No data");
            return;
        }

        if (Product.Id!=id)
        {
            Console.WriteLine("Not exists id : " + id);
            return;
        }

        List.RemoveAt(0);
    }

    public void Update(int id)
    {
        if (List == null)
        {
            Console.WriteLine("No data");
            return;
        }

        if(Product.Id==id)
        {
        List.ForEach(
            pro =>
            {
                if(Product.Id==id)
                {
                    Product.Name = Validation.CheckRegex(Regexx.NAME,"Please enter your name :");
                }
            }
            );
        }

        else
        {
            Console.WriteLine("Not exists id : " + id);
        }
    }
}