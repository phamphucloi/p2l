using System.Net.Http.Headers;

namespace Practice.Models;

public class StudentModel
{
    private List<Students> students;

    public StudentModel()
    {
        students = new List<Students>
        {
            new Students
            {
                    Id = 1,
                    Name = "Phạm Hữu Phúc",
                    Score = 9.0,
                    Gender = true,
                    Picture = "ppl.jpg",
                    Qty = 2,
                    
                    DoB = new DateTime(1970,09,18)
            },

            new Students
            {
                    Id = 2,
                    Name = "Phạm Như Quỳnh",
                    Score = 10,
                    Gender = false,
                    Picture = "ppl.jpg",
                    Qty = 2,
                    DoB = new DateTime(2012,06,29)
            },

            new Students
            {
                    Id = 3,
                    Name = "Nguyễn Thị Ớ",
                    Score = 5,
                    Gender = false,
                    Picture = "ppl.jpg",
                    Qty = 2,
                    DoB = new DateTime(1979,06,19)
            },

            new Students
            {
                Id = 4,
                Name = "Phạm Phúc Lợi",
                Score = 3,
                Gender = true,
                Picture = "ppl.jpg",
                Qty = 2,
                DoB = new DateTime(2003,01,12)
            },

            new Students
            {
                Id = 4,
                Name = "ad",
                Score = 3,
                Gender = true,
                Picture = "ppl.jpg",
                Qty = 2,
                DoB = new DateTime(2003,01,12)
            }
        };
    }

    public List<Students> getAllStudent()
    {
        return students;
    }

    public Students Details(int id)
    {
        return students.FirstOrDefault(stu => stu.Id == id);
    }

    public List<Students> searchByPrice(double min, double max)
    {
        return students.Where(stu => stu.Score >= min && stu.Score <= max).ToList();
    }

    public List<Students> searchByName(string name)
    {
        return students.Where(stu => stu.Name.Contains(name)).ToList();
    }
}
