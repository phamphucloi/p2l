using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practices;
internal class Students
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Boolean Gender { get; set; }
    public DateOnly BirthDay { get; set; }

    public override string ToString()
    {
        return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Gender)}={Gender.ToString()}, {nameof(BirthDay)}={BirthDay.ToString()}}}";
    }
}
