using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListAndLINQ;
internal class Student
{
    public int RollNum { get; set; }
    public string FullName { get; set; }
    public string Section { get; set; }
    public int HotelNum { get; set; }
        
    public override string ToString()
    {
        return $"{{{nameof(RollNum)}={RollNum}, {nameof(FullName)}={FullName}, {nameof(Section)}={Section}, {nameof(HotelNum)}={HotelNum.ToString()}}}";
    }
}
