using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    [RequireComponent(typeof(UIDocument))]
    public class MainMenuUI : MonoBehaviour
    {
        #region UIElements
        
        private VisualElement _root;
        private Button _startGame;
        private Button _exitGame;

        #endregion

        public event Action OnStartGameClick;
        public event Action OnExitGameClick;

        private void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _startGame = _root.Q<Button>("start");
            _exitGame = _root.Q<Button>("exit");
        }

        private void OnEnable()
        {
            _startGame.clicked += StartGameHandler;
            _exitGame.clicked += ExitGameHandler;
        }

        private void OnDisable()
        {
            _startGame.clicked -= StartGameHandler;
            _exitGame.clicked -= ExitGameHandler;
        }

        private void StartGameHandler()
        {
            OnStartGameClick?.Invoke();
        }
        
        private void ExitGameHandler()
        {
            OnExitGameClick?.Invoke();
        }
    }
}