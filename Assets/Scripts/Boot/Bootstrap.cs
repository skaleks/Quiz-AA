using Service;
using UnityEngine;
using Zenject;

namespace Boot
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject] private SceneHandler _sceneHandler;
        
        private void Awake()
        {
            _sceneHandler.LoadScene(SCENE.MAIN);
        }
    }
}