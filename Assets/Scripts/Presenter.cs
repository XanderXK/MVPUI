using System;
using Object = UnityEngine.Object;

namespace MVPUI
{
    public abstract class Presenter<T> : IDisposable where T : View
    {
        protected readonly T _view;
        private bool _isBound;

        public bool IsViewVisible { get; private set; }

        public event Action OnViewShow;
        public event Action OnViewHide;

        protected Presenter()
        {
            var viewPrefab = ViewCatalog.GetPrefab<T>();
            _view = Object.Instantiate(viewPrefab);
        }

        protected abstract void Bind();
        protected abstract void Unbind();

        public void ShowView()
        {
            if (!_isBound)
            {
                Bind();
                _isBound = true;
            }

            if (IsViewVisible) return;
            _view.Show();
            IsViewVisible = true;
            OnViewShow?.Invoke();
        }

        public void HideView()
        {
            if (!IsViewVisible) return;
            _view.Hide();
            IsViewVisible = false;
            OnViewHide?.Invoke();
        }

        public void Dispose()
        {
            OnViewShow = null;
            OnViewHide = null;
            Unbind();
            if (_view)
            {
                Object.Destroy(_view.gameObject);
            }
        }
    }
}