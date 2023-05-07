using RPSAcademyWeb.Models;

namespace RPSAcademyWeb
{
    //summary: providing a common set of behaviors or capabilities that can be implemented by multiple classes
    public interface IMultipleChoiceRepository
    {
        public IEnumerable<MultipleChoice> GetAllProducts();
        public MultipleChoice GetProduct(int id);
        public void UpdateProduct(MultipleChoice question);
        public void InsertProduct(MultipleChoice questionToInsert);
        public void DeleteProduct(MultipleChoice question);
        public MultipleChoice GetNumberOfQuestion();
        public MultipleChoice MultipleChoiceQuestion(int questionNumber);
        public int AnswerChecker(string answer, string correctAnswer);
        public int GivePoint(int scoreToIncrement);
    }
}
