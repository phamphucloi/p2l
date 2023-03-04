namespace DemoSesstion1_MVC.Models;

public class QuestionModel
{

    private List<Question> ques;

    public QuestionModel ()
    {
        ques = new List<Question>()
        {
            new Question()
            {
                Id = 1,
                Name = "Mày tên gì?",
                Answer= new List<Answer>
                {
                    new Answer()
                    {
                        Id = 1,
                        Name = "Lợi",
                        Correst = true
                    },                    
                    new Answer()
                    {
                        Id = 2,
                        Name = "Dot",
                        Correst = false
                    }
                }.ToList(),
            },
            new Question()
            {
                Id = 2,
                Name = "Con bo co may chan?",
                Answer= new List<Answer>
                {
                    new Answer()
                    {
                        Id = 3,
                        Name = "1",
                        Correst = false
                    },
                    new Answer()
                    {
                        Id = 4,
                        Name = "3",
                        Correst = false
                    },
                    new Answer()
                    {
                        Id = 5,
                        Name = "4",
                        Correst = true
                    },
                    new Answer()
                    {
                        Id = 6,
                        Name = "2",
                        Correst = false
                    }
                },
            },            
            new Question()
            {
                Id = 3,
                Name = "May bay co may canh?",
                Answer= new List<Answer>
                {
                    new Answer()
                    {
                        Id = 7,
                        Name = "1",
                        Correst = false
                    },
                    new Answer()
                    {
                        Id = 8,
                        Name = "3",
                        Correst = false
                    },
                    new Answer()
                    {
                        Id = 9,
                        Name = "4",
                        Correst = false
                    },
                    new Answer()
                    {
                        Id = 10,
                        Name = "2",
                        Correst = true
                    }
                },
            },
            new Question()
            {
                Id = 4,
                Name = "Pham Phuc Loi bao nhieu tuoi?",
                Answer= new List<Answer>
                {
                    new Answer()
                    {
                        Id = 11,
                        Name = "19",
                        Correst = false
                    },
                    new Answer()
                    {
                        Id = 12,
                        Name = "30",
                        Correst = false
                    },
                    new Answer()
                    {
                        Id = 13,
                        Name = "41",
                        Correst = false
                    },
                    new Answer()
                    {
                        Id = 14,
                        Name = "20",
                        Correst = true
                    }
                },
            }
        };
    }

    public List<Question> GetAllQuestion()
    {
        return ques;
    }

    public bool IsCorrest(int questionId, int answerId)
    {
        var answers = ques.SingleOrDefault(q=>q.Id==questionId).Answer;
        foreach (var an in answers)
        {
            if (an.Id == answerId && an.Correst)
            {
                return true;
            }
        }
        return false;
    }
}
