using System.Collections.Generic;
using Data;

namespace Core
{
    public class QuizDataDispatcher : IDataDispatcher
    {
        private List<QuizUnit> _quiz;

        public void InitializeQuizData()
        {
            
        }

        public List<QuizUnit> GetQuiz()
        {
            return _quiz;
        }
    }
}