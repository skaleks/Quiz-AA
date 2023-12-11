using System.Collections.Generic;
using System.IO;
using Data;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace Core
{
    public class QuizDataDispatcher : IDataDispatcher
    {
        private const string IMAGE_STORE = "Assets/Sprites/";
        private const string QUIZ_STORE = "Assets/Data/";
        private List<QuizUnit> _quiz;

        public void InitializeQuizData(string quizName)
        {
            var json = File.ReadAllText(QUIZ_STORE + quizName);
            _quiz = JsonConvert.DeserializeObject<List<QuizUnit>>(json);

            foreach (var unit in _quiz)
            {
                unit.Image = AssetDatabase.LoadAssetAtPath<Sprite>(IMAGE_STORE + unit.Background);
            }
        }

        public List<QuizUnit> GetQuiz()
        {
            return _quiz;
        }
    }
}