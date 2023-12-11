using System.Collections.Generic;
using Data;

namespace Core
{
    public interface IDataDispatcher
    {
        void InitializeQuizData(string quizName);
        List<QuizUnit> GetQuiz();
    }
}