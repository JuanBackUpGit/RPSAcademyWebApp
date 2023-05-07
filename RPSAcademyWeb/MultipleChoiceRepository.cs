using Dapper;
using RPSAcademyWeb.Models;
using System.Data;

namespace RPSAcademyWeb
{
    public class MultipleChoiceRepository : IMultipleChoiceRepository
    {
        //summary: allows the class to establish a connection to a database and use methods provided to execute queries on the database
        private readonly IDbConnection _conn;


        //summary: ensures that each object is using the same connection and prevents unnecessary connections to the database
        public MultipleChoiceRepository(IDbConnection conn)
        {
            _conn = conn;
        }


        //summary: executes query that deletes a question from the database by collecting the questionNumber
        public void DeleteProduct(MultipleChoice question)
        {
            _conn.Execute("Delete From multiplechoice WHERE QuestionNumber = @id;"
                , new { id = question.QuestionNumber });
        }


        //summary: executes query that returns all question from the database
        public IEnumerable<MultipleChoice> GetAllProducts()
        {
            return _conn.Query<MultipleChoice>("SELECT * FROM multiplechoice;");
        }


        //summary: executes query that gets a questions details from the database by collecting the questionNumber
        public MultipleChoice GetProduct(int id)
        {
            return _conn.QuerySingle<MultipleChoice>("SELECT * FROM multiplechoice WHERE QuestionNumber =@id;",
            new { id = id });
        }


        //summary: executes query that inserts a new question from the database by collecting all related information through the parameters
        public void InsertProduct(MultipleChoice questionToInsert)
        {
            _conn.Execute("INSERT INTO multiplechoice (Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer, CorrectAnswerString, Subject) VALUES(@question, @answerA, @answerB, @answerC, @answerD, @correctAnswer, @correctAnswerString, @subject);"
                ,new { question = questionToInsert.Question, answerA = questionToInsert.AnswerA, answerB = questionToInsert.AnswerB, answerC = questionToInsert.AnswerC, answerD = questionToInsert.AnswerD, correctAnswer = questionToInsert.CorrectAnswer, correctAnswerString = questionToInsert.CorrectAnswerString, subject = questionToInsert.Subject });
        }


        //summary: executes query that updates a question from the database by collecting the questionNumber
        public void UpdateProduct(MultipleChoice ques)
        {
            _conn.Execute("Update multiplechoice SET Question = @question, AnswerA = @answerA, AnswerB = @answerB, AnswerC = @answerC, AnswerD = answerD, CorrectAnswer = @correctAnswer, CorrectAnswerString = @correctAnswerString, Subject = @subject WHERE QuestionNumber = @id"
                ,new{ question = ques.Question, answerA = ques.AnswerA,  answerB = ques.AnswerB, answerC = ques.AnswerC, answerD = ques.AnswerD, correctAnswer = ques.CorrectAnswer, correctAnswerString = ques.CorrectAnswerString, subject = ques.Subject, id = ques.QuestionNumber});
        }


        //summary: executes query that collects the number of total questions, this allows for the code to not be updated after the amount of questions have been modified
        public MultipleChoice GetNumberOfQuestion()
        {
            return _conn.QuerySingle<MultipleChoice>("Select Count(distinct QuestionNumber) as \"TotalQuestionNumber\" from multiplechoice;");
        }


        //summary: executes query that selects all information from a selected question to use in the question protion of the rps game
        public MultipleChoice MultipleChoiceQuestion(int questionNumber)
        {
            return _conn.QuerySingle<MultipleChoice>($"SELECT * FROM multiplechoice WHERE QuestionNumber = {questionNumber};");
        }

        //summary: checks users answer to a question when playing the game.
        //returns: 1 if user answers correctly
        //         2 if user answers incorrectly
        public int AnswerChecker (string answer, string correctAnswer)
        {
            switch (correctAnswer.ToLower())
            {
                case "a":
                    if(answer == "a")
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                case "b":
                    if (answer == "b")
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                case "c":
                    if (answer == "c")
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                case "d":
                    if (answer == "d")
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                default:
                    return 0;


            }
        }


        //summary: Increases score of the int inserted in the parameters
        //returns: score incremented by 1 point
        public int GivePoint(int scoreToIncrement)
        {
            return scoreToIncrement++;
        }
    }
}