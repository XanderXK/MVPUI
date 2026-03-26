using System.Collections.Generic;

namespace MVPUI.Example
{
    public class InventoryPresenter : Presenter<InventoryView>
    {
        private readonly Inventory _inventory;

        public InventoryPresenter(Inventory inventory)
        {
            _inventory = inventory;
        }

        protected sealed override void Bind()
        {
            _view.OnAddItemClicked += OnAddItemClickedHandler;
            _view.OnRemoveItemClicked += OnRemoveItemClickedHandler;
            _inventory.OnInventoryUpdated += OnInventoryUpdatedHandler;
        }

        private void OnAddItemClickedHandler()
        {
            _inventory.AddItem();
        }

        private void OnRemoveItemClickedHandler(string item)
        {
            _inventory.RemoveItem(item);
        }

        private void OnInventoryUpdatedHandler(IReadOnlyList<string> items)
        {
            _view.UpdateItems(items);
        }

        protected override void Unbind()
        {
            _view.OnAddItemClicked -= OnAddItemClickedHandler;
            _view.OnRemoveItemClicked -= OnRemoveItemClickedHandler;
            _inventory.OnInventoryUpdated -= OnInventoryUpdatedHandler;
        }
    }
}