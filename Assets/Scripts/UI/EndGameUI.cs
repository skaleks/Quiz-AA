using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    [RequireComponent(typeof(UIDocument))]
    public class EndGameUI : MonoBehaviour
    {
        #region UIElements

        private VisualElement _root;
        private VisualElement _screen;
        private Label _pointsText;
        private Button _exitButton;

        #endregion

        private const string BYE_TEXT = "Спасибо за игру! Вы набрали: ";
        public event Action OnExitCkick;

        private void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _screen = _root.Q<VisualElement>("screen");
            _pointsText = _root.Q<Label>("points");
            _exitButton = _root.Q<Button>("exit");
        }

        private void OnEnable()
        {
            _exitButton.clicked += OnExitClickHandler;
        }

        private void OnDisable()
        {
            _exitButton.clicked -= OnExitClickHandler;
        }

        private void OnExitClickHandler()
        {
            OnExitCkick?.Invoke();
            Hide();
        }

        public void ShowEndGameWindow(int points)
        {
            _pointsText.text = BYE_TEXT + points;
            _screen.style.display = DisplayStyle.Flex;
        }

        private void Hide()
        {
            _screen.style.display = DisplayStyle.None;
        }
    }
}