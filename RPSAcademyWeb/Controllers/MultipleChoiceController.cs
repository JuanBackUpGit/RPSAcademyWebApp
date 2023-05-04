﻿using Microsoft.AspNetCore.Mvc;
using RPSAcademyWeb.Models;

namespace RPSAcademyWeb.Controllers
{
    public class MultipleChoiceController : Controller
    {
        private readonly IMultipleChoiceRepository repo;
        public MultipleChoiceController(IMultipleChoiceRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var products = repo.GetAllProducts();
            return View(products);
        }
        public IActionResult ViewQuestion(int id)
        {
            var products = repo.GetProduct(id);

            return View(products);
        }
        public IActionResult SetName()
        {
            var products = repo.GetNumberOfQuestion();
            return View(products);
        }
        public IActionResult UpdateQuestion(int id)
        {
            MultipleChoice ques = repo.GetProduct(id);

            if( ques == null)
            {
                return View("QuestionNotFound");
            }

            return View(ques);

        }
        public IActionResult UpdateQuestionToDatabase(MultipleChoice que)
        {
            repo.UpdateProduct(que);

            return RedirectToAction("ViewQuestion", new {id = que.QuestionNumber});
        }
        public IActionResult InsertQuestion()
        {
            var question = new MultipleChoice();

            return View(question);
        }
        public IActionResult InsertQuestionToDatabase(MultipleChoice que) 
        {
            repo.InsertProduct(que);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteQuestion(MultipleChoice que)
        {
            repo.DeleteProduct(que);

            return RedirectToAction("Index");
        }
        public IActionResult ResultOfQuestionRPS(int winPoint, string userName, string oppImage, string oppName, string oppDescription, string oppStats, List<int> oppDifficulty, int userScore, int oppScore, int totalQuestionNumber ,int selectedQuestion, string answer, string correctAnswer)
        {
            ViewData.Clear();
            ViewBag.winPoint = winPoint;
            ViewBag.userName = userName;
            ViewBag.oppImage = oppImage;
            ViewBag.oppName = oppName;
            ViewBag.oppDescription = oppDescription;
            ViewBag.oppstats = oppStats;
            ViewBag.oppDifficulty = oppDifficulty;
            ViewBag.userScore = userScore;
            ViewBag.oppScore = oppScore;
            ViewBag.totalQuestionNumber = totalQuestionNumber;
            var path = repo.AnswerChecker(answer, correctAnswer);
            switch (path)
            {
                case 1:
                    ViewBag.path = path;
                    ViewBag.userScore = ViewBag.userScore + 1;
                    return View();
               
                case 2:
                    ViewBag.path = path;
                    var questionForRPS = repo.MultipleChoiceQuestion(selectedQuestion);
                    return View(questionForRPS);

                default:
                    return View();

            }
        }
        /*public IActionResult GetQuestionForRPS(int oppID, int winPoint, string userName, int userScore, string oppName, int oppScore, int totalQuestionNumber, string oppImage, int path)
        {
            ViewBag.OppID = oppID;
            ViewBag.WinPoint = winPoint;
            ViewBag.UserName = userName;
            ViewBag.UserScore = userScore;
            ViewBag.OppScore = oppScore;
            ViewBag.TotalQuestionNumber = totalQuestionNumber;
            ViewBag.OppName = oppName;
            ViewBag.OppImage = oppImage;
            ViewBag.Path = path;
            
            Random random = new Random();
            var randomQuestion = random.Next(1, totalQuestionNumber);
            ViewBag.QuestionNumber = randomQuestion;
            var question = repo.MultipleChoiceQuestion(randomQuestion);

            return View(question);
        }*/
    }
}