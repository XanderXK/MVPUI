using System;
using System.Collections.Generic;

namespace MVPUI.Example
{
    public class Inventory
    {
        private readonly List<string> _items = new();

        public event Action<IReadOnlyList<string>> OnInventoryUpdated;

        public void AddItem()
        {
            _items.Add($"Item_{_items.Count}");
            OnInventoryUpdated?.Invoke(_items);
        }

        public void RemoveItem(string item)
        {
            if (_items.Remove(item))
            {
                OnInventoryUpdated?.Invoke(_items);
            }
        }
    }
}