using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    [RequireComponent(typeof(UIDocument))]
    public class QuizUI : MonoBehaviour
    {
        private VisualElement _root;
        
        private void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
        }
    }
}