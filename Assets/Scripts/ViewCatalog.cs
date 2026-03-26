using System.Linq;
using UnityEngine;

namespace MVPUI
{
    [CreateAssetMenu(menuName = "MVPUI/View Catalog", fileName = "ViewCatalog")]
    public class ViewCatalog : ScriptableObject
    {
        [SerializeField] private View[] _views;

        private static ViewCatalog _viewCatalog;

        public static T GetPrefab<T>() where T : View
        {
            if (!_viewCatalog)
            {
                _viewCatalog = Resources.Load<ViewCatalog>(nameof(ViewCatalog));
            }

            return (T)_viewCatalog._views.FirstOrDefault(v => v is T);
        }
    }
}