using Dapper;
using RPSAcademyWeb.Models;
using System.Data;

namespace RPSAcademyWeb
{
    public class MultipleChoiceRepository : IMultipleChoiceRepository
    {
        private readonly IDbConnection _conn;

        public MultipleChoiceRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public void DeleteProduct(MultipleChoice question)
        {
            _conn.Execute("Delete From multiplechoice WHERE QuestionNumber = @id;"
                , new { id = question.QuestionNumber });
        }

        public IEnumerable<MultipleChoice> GetAllProducts()
        {
            return _conn.Query<MultipleChoice>("SELECT * FROM multiplechoice;");
        }

        public MultipleChoice GetProduct(int id)
        {
            return _conn.QuerySingle<MultipleChoice>("SELECT * FROM multiplechoice WHERE QuestionNumber =@id;",
            new { id = id });
        }

        public void InsertProduct(MultipleChoice questionToInsert)
        {
            _conn.Execute("INSERT INTO multiplechoice (Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer, CorrectAnswerString, Subject) VALUES(@question, @answerA, @answerB, @answerC, @answerD, @correctAnswer, @correctAnswerString, @subject);"
                ,new { question = questionToInsert.Question, answerA = questionToInsert.AnswerA, answerB = questionToInsert.AnswerB, answerC = questionToInsert.AnswerC, answerD = questionToInsert.AnswerD, correctAnswer = questionToInsert.CorrectAnswer, correctAnswerString = questionToInsert.CorrectAnswerString, subject = questionToInsert.Subject });
        }

        public void UpdateProduct(MultipleChoice ques)
        {
            _conn.Execute("Update multiplechoice SET Question = @question, AnswerA = @answerA, AnswerB = @answerB, AnswerC = @answerC, AnswerD = answerD, CorrectAnswer = @correctAnswer, CorrectAnswerString = @correctAnswerString, Subject = @subject WHERE QuestionNumber = @id"
                ,new{ question = ques.Question, answerA = ques.AnswerA,  answerB = ques.AnswerB, answerC = ques.AnswerC, answerD = ques.AnswerD, correctAnswer = ques.CorrectAnswer, correctAnswerString = ques.CorrectAnswerString, subject = ques.Subject, id = ques.QuestionNumber});
        }
    }
}