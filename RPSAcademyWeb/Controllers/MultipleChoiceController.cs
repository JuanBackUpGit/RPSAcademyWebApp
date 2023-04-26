using Microsoft.AspNetCore.Mvc;
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
    }
}
