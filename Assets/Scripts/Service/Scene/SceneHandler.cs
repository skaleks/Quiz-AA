using UnityEngine.SceneManagement;

namespace Service
{
    public class SceneHandler
    {
        public void LoadScene(string title)
        {
            SceneManager.LoadSceneAsync(title, LoadSceneMode.Single);
        }
    }
}