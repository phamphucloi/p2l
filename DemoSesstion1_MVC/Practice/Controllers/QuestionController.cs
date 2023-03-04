using Microsoft.AspNetCore.Mvc;
using Practice.Models.Questions;
using System.Diagnostics;

namespace Practice.Controllers
{
    [Route("question")]
    public class QuestionController : Controller
    {
        [Route("index")]
        [Route("~/")]
        [Route("")]
        public IActionResult Index()
        {
            var questions = new Question();
            var model = new QuestionModel();
            ViewBag.questions = model.GetAllQuestion();
            return View("Index", questions);
        }

        [Route("index")]
        [HttpPost]
        public IActionResult Index(Question questions)
        {

            int score = 0;

            var model = new QuestionModel();

            foreach (var question in model.GetAllQuestion())
            {
                var answerId = HttpContext.Request.Form["question_" + question.QuestionId].ToString();

                if (model.GetIsCorrest(question.QuestionId, Convert.ToInt32(answerId)))
                {
                    score++;
                }

                Debug.WriteLine("câu hỏi có id là : " + question.QuestionId);
                Debug.WriteLine("câu trả lời có id là : " + answerId);
            }
            ViewBag.score = score;
            return View("Result");
        }
    }

};
