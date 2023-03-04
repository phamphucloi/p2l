using DemoSesstion1_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoSesstion1_MVC.Controllers
{
    [Route("answer")]
    public class AnswerController : Controller
    {
        [Route("index")]
        //[Route("~/")]
        public IActionResult Index()
        {
            var question = new Question(){};
            var model = new QuestionModel();
            ViewBag.questions = model.GetAllQuestion();
            return View("index", question);
        }

        [HttpPost]
        [Route("index")]
        public IActionResult Index(Question ques)
        {
            var score = 0;

            var model = new QuestionModel();

            foreach (var question in model.GetAllQuestion())
            {
                var answerId = int.Parse(HttpContext.Request.Form["question_" + question.Id].ToString());

                if (model.IsCorrest(question.Id, answerId))
                {
                    score++;
                }

                Debug.WriteLine("Câu hỏi có id là : " + question.Id);
                Debug.WriteLine("trả lời : " + answerId + "\n");
            }

            ViewBag.score = score;
            return View("Result");
        }
    }

};
