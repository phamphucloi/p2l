namespace Practice.Models.Questions;

public class Question
{
    public int QuestionId { get; set; }
    public string Content { get; set; }
    public List<Answer> Answers { get; set; }
}
