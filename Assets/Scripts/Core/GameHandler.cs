using System;
using System.Collections.Generic;
using Data;
using UI;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private QuizUI _quizUI;
        [SerializeField] private ConfirmUI _confirmUI;
        [SerializeField] private EndGameUI _endGameUI;
        [Inject] private IDataDispatcher _dataDispatcher;

        private List<QuizUnit> _quiz;
        private QuizUnit _currentQuizStep;
        private int _questionsCounter = 0;
        private int _correctAnswerCounter = 0;
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
            _confirmUI.OnNextCkick += NextQuestion;
            _endGameUI.OnExitCkick += ExitGame;
        }

        private void OnDisable()
        {
            _quizUI.OnClickAnswer1 -= OnGetAnswerHandler;
            _quizUI.OnClickAnswer2 -= OnGetAnswerHandler;
            _quizUI.OnClickAnswer3 -= OnGetAnswerHandler;
            _quizUI.OnClickAnswer4 -= OnGetAnswerHandler;
            _confirmUI.OnNextCkick -= NextQuestion;
            _endGameUI.OnExitCkick -= ExitGame;
        }

        private void InitializeGame(List<QuizUnit> quiz)
        {
            if (quiz == null)
            {
                throw new ArgumentNullException();
            }

            _quiz = quiz;
            _currentQuizStep = quiz[_questionsCounter];
            PrepareUI(_currentQuizStep);
        }

        private void PrepareUI(QuizUnit quiz)
        {
            _quizUI.SetQuestion(quiz.Question);
            _quizUI.SetBackgroundImage(quiz.Image);
            
            List<string> answers = new ();
            foreach (var answer in quiz.Answers)
            {
                answers.Add(answer.Text);
            }

            _quizUI.SetAnswers(answers);
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

        private void CorrectHandler()
        {
            _correctAnswerCounter++;
            _confirmUI.Show(true);
        }

        private void IncorrectHandler()
        {
            _confirmUI.Show(false);
        }

        private void NextQuestion()
        {
            _questionsCounter++;
            
            if (_questionsCounter == _quiz.Count)
            {
                _endGameUI.ShowEndGameWindow(_correctAnswerCounter);
                return;
            }

            _currentQuizStep = _quiz[_questionsCounter];
            PrepareUI(_currentQuizStep);
        }
        
        private void ExitGame()
        {
            Application.Quit();
        }
    }
}