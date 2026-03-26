using UnityEngine;

namespace MVPUI.Example
{
    public class EntryPoint : MonoBehaviour
    {
        private InventoryPresenter _inventoryPresenter;

        private void Start()
        {
            var inventory = new Inventory();
            _inventoryPresenter = new InventoryPresenter(inventory);
            _inventoryPresenter.ShowView();
        }

        private void OnDestroy()
        {
            _inventoryPresenter.Dispose();
        }
    }
}