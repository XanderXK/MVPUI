using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace MVPUI.Example
{
    public class InventoryView : View
    {
        [SerializeField] private InventoryButtonElement _inventoryItemPrefab;
        [SerializeField] private Button _addButton;
        [SerializeField] private Button _removeButton;
        [SerializeField] private Transform _itemsContainer;

        private InventoryButtonElement _selectedItem;
        private readonly List<InventoryButtonElement> _inventoryButtonElements = new();

        public event Action OnAddItemClicked;
        public event Action<string> OnRemoveItemClicked;

        protected override void Init()
        {
            _addButton.onClick.AddListener(OnAddItemClickHandler);
            _removeButton.onClick.AddListener(OnRemoveItemClickHandler);
        }

        private void OnAddItemClickHandler()
        {
            OnAddItemClicked?.Invoke();
        }

        private void OnRemoveItemClickHandler()
        {
            if (!_selectedItem) return;
            OnRemoveItemClicked?.Invoke(_selectedItem.ItemName);
        }

        public void UpdateItems(IReadOnlyList<string> items)
        {
            foreach (var item in _inventoryButtonElements)
            {
                item.OnClicked -= OnItemClickedHandler;
                Destroy(item.gameObject);
            }

            _inventoryButtonElements.Clear();

            foreach (var item in items)
            {
                var itemElement = Instantiate(_inventoryItemPrefab, _itemsContainer);
                _inventoryButtonElements.Add(itemElement);
                itemElement.Init(item);
                itemElement.OnClicked += OnItemClickedHandler;
            }

            _selectedItem = _inventoryButtonElements.Count > 0
                ? _inventoryButtonElements[^1]
                : null;

            _selectedItem?.Select();
        }

        private void OnItemClickedHandler(InventoryButtonElement inventoryButtonElement)
        {
            _selectedItem = inventoryButtonElement;
        }
    }
}