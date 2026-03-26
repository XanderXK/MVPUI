using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace MVPUI.Example
{
    public class InventoryView : View
    {
        [SerializeField] private VisualTreeAsset _inventoryItemTemplate;

        private Button _addButton;
        private Button _removeButton;
        private ListView _itemsListView;
        private readonly List<string> _items = new();

        public event Action OnAddItemClicked;
        public event Action<string> OnRemoveItemClicked;

        protected override void Init()
        {
            _itemsListView = _root.Q<ListView>("ItemsListView");
            _itemsListView.itemsSource = _items;
            _itemsListView.makeItem = () => _inventoryItemTemplate.Instantiate();
            _itemsListView.bindItem = (element, index) => { element.Q<Label>("ItemLabel").text = _items[index]; };

            _addButton = _root.Q<Button>("AddButton");
            _removeButton = _root.Q<Button>("RemoveButton");

            _addButton.RegisterCallback<ClickEvent>(OnAddItemClickHandler);
            _removeButton.RegisterCallback<ClickEvent>(OnRemoveItemClickHandler);
        }

        private void OnAddItemClickHandler(ClickEvent evt)
        {
            OnAddItemClicked?.Invoke();
        }

        private void OnRemoveItemClickHandler(ClickEvent evt)
        {
            var selectedIndex = _itemsListView.selectedIndex;
            if (selectedIndex < 0 || selectedIndex >= _items.Count) return;
            var selectedItem = _items[selectedIndex];
            OnRemoveItemClicked?.Invoke(selectedItem);
        }

        public void UpdateItems(IReadOnlyList<string> newItems)
        {
            _items.Clear();
            _items.AddRange(newItems);
            _itemsListView.RefreshItems();
            if (_itemsListView.selectedIndex == -1 && _items.Count > 0)
            {
                _itemsListView.selectedIndex = 0;
            }
        }
    }
}