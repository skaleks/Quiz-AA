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

        #endregion

        public event Action OnStartGameClick; 

        private void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _startGame = _root.Q<Button>("start");
        }

        private void OnEnable()
        {
            _startGame.clicked += StartGameHandler;
        }

        private void OnDisable()
        {
            _startGame.clicked -= StartGameHandler;
        }

        private void StartGameHandler()
        {
            OnStartGameClick?.Invoke();
        }
    }
}