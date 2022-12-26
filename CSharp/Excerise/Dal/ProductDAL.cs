using Entity;
using Excerise.ExtentionMethod;
using Excerise.Helper;
using Excerise.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excerise.Dal;
internal class ProductDAL : IProduct
{
    public List<Products> ListPro { get; set; } = new();

    public void AddProduct() 
    {
        Console.WriteLine("Enter the number of product : ");
        int n = Validation<int>.CheckReadLine();

        for (int i = 0; i < n; i++)
        {
            Products pro = new();
            Console.WriteLine($"product[{i+1}]=> enter id product : ");

            pro.Id = Validation<string>.CheckReadLine();

            ListPro.Add(pro);
        }
    }
    //object ỳ ní xô lai
}
