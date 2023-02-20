namespace Test.Models;

public class StudentModel
{
    private List<Student> students;

    public StudentModel()
    {
        var stu = new List<Student>
        {
            new Student
            {
                    Id = 1,
                    Name = "Phạm Phúc Lợi"
            },
                        new Student
            {
                    Id = 2,
                    Name = "Phạm Phúc Lợi"
            },
                                    new Student
            {
                    Id = 3,
                    Name = "Phạm Phúc Lợi"
            },
        };
    }

    public List<Student> getAllStudent()
    {
        return students;
    }
}
