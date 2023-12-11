using System;
using System.Collections.Generic;
using Data;
using ModestTree;
using UI;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private QuizUI _quizUI;
        [Inject] private IDataDispatcher _dataDispatcher;

        private QuizUnit _currentQuizStep;
        private void Start()
        {
            var quiz =_dataDispatcher.GetQuiz();
            InitializeGame(quiz);
        }

        private void OnEnable()
        {
            _quizUI.OnClickAnswer1 += OnGetAnswerHandler;
            _quizUI.OnClickAnswer2 += OnGetAnswerHandler;
            _quizUI.OnClickAnswer3 += OnGetAnswerHandler;
            _quizUI.OnClickAnswer4 += OnGetAnswerHandler;
        }

        private void OnDisable()
        {
            _quizUI.OnClickAnswer1 -= OnGetAnswerHandler;
            _quizUI.OnClickAnswer2 -= OnGetAnswerHandler;
            _quizUI.OnClickAnswer3 -= OnGetAnswerHandler;
            _quizUI.OnClickAnswer4 -= OnGetAnswerHandler;
        }

        private void InitializeGame(List<QuizUnit> quizUnits)
        {
            if (quizUnits == null || quizUnits.IsEmpty())
            {
                throw new ArgumentNullException();
            }
            
            _currentQuizStep = quizUnits[0];
            
        }

        private void OnGetAnswerHandler(int answerNumber)
        {
            if (_currentQuizStep.Answers[answerNumber].Correct)
            {
                CorrectHandler();
            }
            else
            {
                IncorrectHandler();
            }
        }

        private void IncorrectHandler()
        {
            
        }

        private void CorrectHandler()
        {
            
        }
    }
}