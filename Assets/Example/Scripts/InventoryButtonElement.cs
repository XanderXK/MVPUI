using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVPUI.Example
{
    public class InventoryButtonElement : MonoBehaviour
    {
        [SerializeField] private TMP_Text _itemNameText;
        [SerializeField] private Button _button;

        public string ItemName { get; private set; }

        public event Action<InventoryButtonElement> OnClicked;

        public void Init(string itemName)
        {
            ItemName = itemName;
            _itemNameText.text = ItemName;
            OnClicked?.Invoke(this);
        }

        public void Select()
        {
            _button.Select();
        }
    }
}