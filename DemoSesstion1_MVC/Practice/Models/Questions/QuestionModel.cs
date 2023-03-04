using DemoSesstion1_MVC.Models;
using System.Diagnostics;

namespace Practice.Models.Questions;

public class QuestionModel
{
    public List<Question> ques { get; set; }

    public QuestionModel()
    {
        ques = new List<Question>()
        {
            new Question()
            {
                QuestionId = 1,
                Content = "Con bò có mấy chân?",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        AnswerId = 1,
                        AnswersTitle = "2",
                        IsCorrest = false
                    },
                    new Answer()
                    {
                        AnswerId = 2,
                        AnswersTitle = "3",
                        IsCorrest = false
                    },
                    new Answer()
                    {
                        AnswerId = 3,
                        AnswersTitle = "5",
                        IsCorrest = false
                    },
                    new Answer()
                    {
                        AnswerId = 4,
                        AnswersTitle = "4",
                        IsCorrest = true
                    }
                }
            },
            new Question()
            {
                QuestionId = 2,
                Content = "Phạm Phúc Lợi bao nhiêu tuổi?",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        AnswerId = 5,
                        AnswersTitle = "20",
                        IsCorrest = true
                    },
                    new Answer()
                    {
                        AnswerId = 6,
                        AnswersTitle = "31",
                        IsCorrest = false
                    },
                    new Answer()
                    {
                        AnswerId = 7,
                        AnswersTitle = "25",
                        IsCorrest = false
                    },
                    new Answer()
                    {
                        AnswerId = 8,
                        AnswersTitle = "24",
                        IsCorrest = false
                    }
                }
            },
            new Question()
            {
                QuestionId = 3,
                Content = "Phạm Phúc Lợi handsome?",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        AnswerId = 9,
                        AnswersTitle = "Vừa Vừa",
                        IsCorrest = false
                    },
                    new Answer()
                    {
                        AnswerId = 10,
                        AnswersTitle = "Đẹp trai khủng khiếp. ((:",
                        IsCorrest = false
                    },
                    new Answer()
                    {
                        AnswerId = 11,
                        AnswersTitle = "Đẹp trai",
                        IsCorrest = true
                    },
                    new Answer()
                    {
                        AnswerId = 12,
                        AnswersTitle = "Nhìn được",
                        IsCorrest = false
                    }
                }
            },
        };
    }

    public List<Question> GetAllQuestion()
    {
        return ques;
    }

    public bool GetIsCorrest(int questionId, int answerId)
    {
        var answers = ques.SingleOrDefault(q=>q.QuestionId==questionId).Answers;

        Debug.WriteLine("answer có id là : " + answers);

        foreach(var answer in answers)
        {
            if (answer.AnswerId == answerId && answer.IsCorrest)
            {
                return true;
            }
        }
        return false;
    }

}
