using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student;
class Class1
{
    private int id;
    private string name;
    private int age;
    private string email;
    
    public  Class1() { }

    public Class1(int id, string name, int age, string email) {
        this.id = id;
        this.name = name;
        this.age = age;
        this.email = email;
    }

    public object MessageBox { get; private set; }

    public void setAge(int age)
    {
        if (age > 0 && age <= 100)
        {
            this.age = age;
        }
        else
        {
            Console.WriteLine("Not available");
        }
    }

    public int getAge()
    {
        return age;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public string getId() {
        return name;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public string getName()
    {
        return name;
    }

    public void setEmail(string email)
    {
        this.email = email;
    }

    public string getEmail()
    {
        return email;
    }
}

