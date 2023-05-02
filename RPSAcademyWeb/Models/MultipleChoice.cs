namespace RPSAcademyWeb.Models
{
    public class MultipleChoice
    {
        public MultipleChoice()
        {

        }
        public int? QuestionNumber { get; set; }
        public string? Question { get; set; }
        public string? AnswerA { get; set; }
        public string? AnswerB { get; set; }
        public string? AnswerC { get; set; }
        public string? AnswerD { get; set; }
        public string? CorrectAnswer { get; set; }
        public string? CorrectAnswerString { get; set; }
        public string? Subject { get; set; }

        public int TotalQuestionNumber { get; set; }
    }
}
