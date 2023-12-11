using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    [RequireComponent(typeof(UIDocument))]
    public class QuizUI : MonoBehaviour
    {
        private VisualElement _root;
        private VisualElement _screen;
        private Label _question;
        private Button _answerButton1;
        private Button _answerButton2;
        private Button _answerButton3;
        private Button _answerButton4;

        private List<Button> _buttons = new();

        private void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _screen = _root.Q<VisualElement>("screen");
            _question = _root.Q<Label>("question_text");
            _answerButton1 = _root.Q<Button>("answer_1");
            _answerButton2 = _root.Q<Button>("answer_2");
            _answerButton3 = _root.Q<Button>("answer_3");
            _answerButton4 = _root.Q<Button>("answer_4");
        }

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        public void SetBackgroundImage(Sprite sprite)
        {
            _screen.style.backgroundImage = new StyleBackground(sprite);
        }

        public void SetQuestion(string question)
        {
            _question.text = question;
        }

        public void SetAnswers(string[] answers)
        {
            var index = 0;
            foreach (var button in _buttons)
            {
                button.text = answers[index];
                index++;
            }
        }
    }
}