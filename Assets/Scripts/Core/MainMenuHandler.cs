using Data;
using Service;
using UI;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainMenuHandler : MonoBehaviour
    {
        [SerializeField] private MainMenuUI _menuUI;
        [Inject] private SceneHandler _sceneHandler;
        [Inject] private IDataDispatcher _dataDispatcher;

        private void OnEnable()
        {
            _menuUI.OnStartGameClick += StartGame;
            _menuUI.OnExitGameClick += QuitGame;
        }

        private void OnDisable()
        {
            _menuUI.OnStartGameClick -= StartGame;
            _menuUI.OnExitGameClick -= QuitGame;
        }

        private void StartGame()
        {
            _dataDispatcher.InitializeQuizData(QUIZCONSTANTS.SIMPLE);
            _sceneHandler.LoadScene(SCENE.MAIN);
        }
        
        private void QuitGame()
        {
            Application.Quit();
        }
    }
}