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
    }

    public void SelectItem()
    {
        PlayerInventory.Instance.SelectedItem.ItemIcon.UnSelectItem();
        PlayerInventory.Instance.SelectedItem = _itemSORef;
        _imageRef.sprite = _selectedSprite;
    }

    public void UnSelectItem()
    {
        _imageRef.sprite = _unselectedSprite;
        PlayerInventory.Instance.SelectedItem = null;
    }
}
