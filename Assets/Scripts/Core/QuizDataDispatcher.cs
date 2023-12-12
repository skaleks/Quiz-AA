using System.Collections.Generic;
using System.IO;
using Data;
using Newtonsoft.Json;
using UnityEngine;

namespace Core
{
    public class QuizDataDispatcher : IDataDispatcher
    {
        private const string QUIZ_STORE = "/Data/";
        private List<QuizUnit> _quiz;

        public void InitializeQuizData(string quizName)
        {
            var jsonPath = Path.Combine(Application.streamingAssetsPath, QUIZ_STORE, quizName);
            var json = File.ReadAllText(jsonPath);
            _quiz = JsonConvert.DeserializeObject<List<QuizUnit>>(json);

            foreach (var unit in _quiz)
            {
                var path = unit.Background.Split('.');
                unit.Image = Resources.Load<Sprite>(path[0]); 
            }
        }

        public List<QuizUnit> GetQuiz()
        {
            return _quiz;
        }
    }
}