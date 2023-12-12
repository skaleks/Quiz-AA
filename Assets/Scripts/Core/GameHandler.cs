using System;
using System.Collections.Generic;
using Data;
using Service;
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
        [Inject] private SceneHandler _sceneHandler;

        private List<QuizUnit> _quiz;
        private QuizUnit _currentQuizStep;
        private Answer _correctAnswer;
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
            _quiz = quiz ?? throw new ArgumentNullException();
            _currentQuizStep = quiz[_questionsCounter];
            PrepareQuestion(_currentQuizStep);
        }

        private void PrepareQuestion(QuizUnit quiz)
        {
            _quizUI.SetQuestionText(quiz.Question);
            _quizUI.SetBackgroundImage(quiz.Image);
            
            List<string> answers = new ();
            foreach (var answer in quiz.Answers)
            {
                if (answer.Correct)
                {
                    _correctAnswer = answer;
                }
                
                answers.Add(answer.Text);
            }

            _quizUI.SetAnswers(answers);
        }

        private void OnGetAnswerHandler(int answerNumber)
        {
            if (_questionsCounter == _quiz.Count - 1)
            {
                _confirmUI.SetEndGameText();
            }
            
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
            _confirmUI.Show(false, _correctAnswer.Text);
        }

        private void NextQuestion()
        {
            _quizUI.EnableInput();
            _quizUI.ResetVariantColor();
            _questionsCounter++;
            
            if (_questionsCounter == _quiz.Count)
            {
                _endGameUI.ShowEndGameWindow(_correctAnswerCounter);
                return;
            }

            _currentQuizStep = _quiz[_questionsCounter];
            PrepareQuestion(_currentQuizStep);
        }
        
        private void ExitGame()
        {
            _sceneHandler.LoadScene(SCENE.MENU);
        }
    }
}