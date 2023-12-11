using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    [RequireComponent(typeof(UIDocument))]
    public class ConfirmUI : MonoBehaviour
    {
        #region UIElements

        private VisualElement _root;
        private VisualElement _confirmWindow;
        private VisualElement _screen;
        private Label _correctText;
        private Button _nextButton;

        #endregion

        private const string CORRECT_ANSWER = "Правильно!";
        private const string INCORRECT_ANSWER = "Неправильно!";

        public event Action OnNextCkick;
        
        private void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _screen = _root.Q<VisualElement>("screen");
            _confirmWindow = _root.Q<VisualElement>("confirm_window");
            _correctText = _root.Q<Label>("text");
            _nextButton = _root.Q<Button>("next");
        }

        private void OnEnable()
        {
            _nextButton.clicked += OnNextClickHandler;
        }

        private void OnDisable()
        {
            _nextButton.clicked -= OnNextClickHandler;
        }

        private void OnNextClickHandler()
        {
            OnNextCkick?.Invoke();
            Hide();
        }

        private void Hide()
        {
            _screen.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.None);
        }

        public void Show(bool value)
        {
            _screen.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.Flex);
            _confirmWindow.style.backgroundColor = value ? new StyleColor(Color.green) : new StyleColor(Color.red);
            _correctText.text = value ? CORRECT_ANSWER : INCORRECT_ANSWER;
        }
    }
}