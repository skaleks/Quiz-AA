using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    [RequireComponent(typeof(UIDocument))]
    public class QuizUI : MonoBehaviour
    {
        #region UIElements
        
        private VisualElement _root;
        private VisualElement _screen;
        private Label _question;
        private Button _answerButton1;
        private Button _answerButton2;
        private Button _answerButton3;
        private Button _answerButton4;

        #endregion

        private readonly List<Button> _buttons = new();
        private Button _lastPressedButton;
        private Color _answerButtonColor = new(0.8980392f, 0.8666667f, 0.8666667f);
        private Color _chosenAnswerButtonColor = new(0.8329477f, 0.9245283f, 0.9129996f, 0.8882353f);
        public event Action<int> OnClickAnswer1; 
        public event Action<int> OnClickAnswer2; 
        public event Action<int> OnClickAnswer3; 
        public event Action<int> OnClickAnswer4;
        
        private void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _screen = _root.Q<VisualElement>("screen");
            _question = _root.Q<Label>("question_text");
            
            _answerButton1 = _root.Q<Button>("answer_1");
            _buttons.Add(_answerButton1);
            _answerButton2 = _root.Q<Button>("answer_2");
            _buttons.Add(_answerButton2);
            _answerButton3 = _root.Q<Button>("answer_3");
            _buttons.Add(_answerButton3);
            _answerButton4 = _root.Q<Button>("answer_4");
            _buttons.Add(_answerButton4);
        }

        private void OnEnable()
        {
            _answerButton1.clicked += AnswerClickHandler_1;
            _answerButton2.clicked += AnswerClickHandler_2;
            _answerButton3.clicked += AnswerClickHandler_3;
            _answerButton4.clicked += AnswerClickHandler_4;
        }

        private void OnDisable()
        {
            _answerButton1.clicked -= AnswerClickHandler_1;
            _answerButton2.clicked -= AnswerClickHandler_2;
            _answerButton3.clicked -= AnswerClickHandler_3;
            _answerButton4.clicked -= AnswerClickHandler_4;
        }

        private void AnswerClickHandler_1()
        {
            ProcessUI(_answerButton1);
            OnClickAnswer1?.Invoke(0);
        }

        private void AnswerClickHandler_2()
        {
            ProcessUI(_answerButton2);
            OnClickAnswer2?.Invoke(1);
        }

        private void AnswerClickHandler_3()
        {
            ProcessUI(_answerButton3);
            OnClickAnswer3?.Invoke(2);
        }

        private void AnswerClickHandler_4()
        {
            ProcessUI(_answerButton4);
            OnClickAnswer4?.Invoke(3);
        }

        public void SetBackgroundImage(Sprite sprite)
        {
            _screen.style.backgroundImage = new StyleBackground(sprite);
        }

        public void SetQuestion(string question)
        {
            _question.text = question;
        }

        public void SetAnswers(List<string> answers)
        {
            var index = 0;
            foreach (var button in _buttons)
            {
                button.text = answers[index];
                index++;
            }
        }

        private void ProcessUI(Button button)
        {
            button.style.backgroundColor = _chosenAnswerButtonColor;
            _lastPressedButton = button;
            DisableInput();
        }

        private void DisableInput()
        {
            foreach (var button in _buttons)
            {
                button.pickingMode = PickingMode.Ignore;
            }
        }
        
        public void EnableInput()
        {
            foreach (var button in _buttons)
            {
                button.pickingMode = PickingMode.Position;
            }
        }

        public void ResetVariantColor()
        {
            _lastPressedButton.style.backgroundColor = _answerButtonColor;
        }
    }
}