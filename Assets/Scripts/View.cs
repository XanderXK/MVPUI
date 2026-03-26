using UnityEngine;
using UnityEngine.UIElements;

namespace MVPUI
{
    public abstract class View : MonoBehaviour
    {
        protected UIDocument _uiDocument;
        protected VisualElement _root;

        private void Awake()
        {
            _uiDocument = GetComponent<UIDocument>();
            _root = _uiDocument.rootVisualElement;
            Hide();
            Init();
        }

        protected abstract void Init();

        public void Show()
        {
            _root.style.display = DisplayStyle.Flex;
        }

        public void Hide()
        {
            _root.style.display = DisplayStyle.None;
        }
    }
}