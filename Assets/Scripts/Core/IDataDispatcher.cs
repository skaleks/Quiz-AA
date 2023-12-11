using System.Collections.Generic;
using Data;

namespace Core
{
    public interface IDataDispatcher
    {
        void InitializeQuizData();
        List<QuizUnit> GetQuiz();
    }
}