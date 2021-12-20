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
        // if another item is selected right now, unselect it
        if (PlayerInventory.Instance.SelectedItem != null)
        {
            PlayerInventory.Instance.SelectedItem.ItemIcon.UnSelectItem();
        }
        //make this the selected item
        PlayerInventory.Instance.SelectedItem = _itemSORef;
        _imageRef.sprite = _selectedSprite;

        AttachToCursor();
    }

    public void UnSelectItem()
    {
        _imageRef.sprite = _unselectedSprite;
        PlayerInventory.Instance.SelectedItem = null;

        DettachToCursor();
    }

    private void AttachToCursor()
    {
        PlayerInventory.Instance.SelectedItemCursor.sprite = _unselectedSprite;
        PlayerInventory.Instance.SelectedItemCursor.gameObject.SetActive(true);
        Cursor.visible = false;
    }

    private void DettachToCursor()
    {
        PlayerInventory.Instance.SelectedItemCursor.gameObject.SetActive(false);
        Cursor.visible = true;
    }
}
