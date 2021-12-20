using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIcon : MonoBehaviour
{
    private ItemSO _itemSORef;

    private Image _imageRef;

    private Sprite _unselectedSprite;

    private Sprite _selectedSprite;

    public static Action OnSelect;

    private void Start()
    {
        
    }

    public void InitializeItemIcon(ItemSO itemSORef)
    {
        _imageRef = GetComponent<Image>();
        _itemSORef = itemSORef;
        _imageRef.sprite = itemSORef.ItemUnselected;
        _unselectedSprite = itemSORef.ItemUnselected;
        _selectedSprite = itemSORef.ItemSelected;

        _itemSORef.ItemIcon = this;

        OnSelect += UnSelectItem;
    }

    public void SelectItem()
    {
        OnSelect.Invoke();
        PlayerInventory.Instance.SelectedItem = _itemSORef;
        _imageRef.sprite = _selectedSprite;
    }

    public void UnSelectItem()
    {
        PlayerInventory.Instance.SelectedItem = null;
        _imageRef.sprite = _unselectedSprite;
    }
}
