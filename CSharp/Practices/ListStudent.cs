using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practices;
internal class ListStudent
{
    public List<Students> list = new();

    public void InsertStudent()
    {
        Students stu = new()
        {
            Id = Convert.ToInt32(Validation.CheckRegex(Regexs.ID, "Enter Id : ")),
            Name = Validation.CheckRegex(Regexs.NAME, "Enter your name : "),
            Gender = Convert.ToBoolean(Validation.CheckRegex(Regexs.GENDER, "Enter gender : ") == "1" ? true : false),
            BirthDay = DateOnly.Parse(Validation.CheckRegex(Regexs.BIRTHDAY, "Enter birthday : ")),
        };

        list.Add(stu);
    }

    public void SelectAllStudents()
    {
        list.ForEach(Console.WriteLine);
    }

    public void DeleteStudent(int id)
    {
        list.RemoveAll(stu=>stu.Id==id);
    }

    public void UpdateStudent(int id)
    {
        var update = list.Where(stu=>stu.Id==id);
        update.First().Id = Convert.ToInt32(Validation.CheckRegex(Regexs.ID, "Enter Id : "));
        update.First().Name = Validation.CheckRegex(Regexs.NAME, "Enter your name : ");
        update.First().Gender = Convert.ToBoolean(Validation.CheckRegex(Regexs.GENDER, "Enter gender : ") == "1" ? true : false);
        update.First().BirthDay = DateOnly.Parse(Validation.CheckRegex(Regexs.BIRTHDAY, "Enter birthday : "));
    }

    public void SortStudentById()
    {
        list.OrderBy(stu=>stu.Id).ToList().ForEach(Console.WriteLine);
    }

    public void SearchStudentsByName(string name)
    {
        list.Where(stu => stu.Name == name).ToList().ForEach(Console.WriteLine);
    }
}
