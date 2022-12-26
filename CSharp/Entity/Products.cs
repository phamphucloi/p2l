using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity;
public class Products
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Double Price { get; set; }
    public int Qty { get; set; }
    public DateOnly DoB { get; set; }

    public override string ToString()
    {
        return $"{{{nameof(Id)}={Id}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}, {nameof(Qty)}={Qty.ToString()}, {nameof(DoB)}={DoB.ToString()}}}";
    }

}
