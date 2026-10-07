using UnityEngine;

namespace MVPUI
{
    public abstract class View : MonoBehaviour
    {
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            Hide();
            Init();
        }

        protected abstract void Init();

        public void Show()
        {
            _canvas.enabled = true;
        }

        public void Hide()
        {
            _canvas.enabled = false;
        }
    }
}