using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIcon : MonoBehaviour
{
    
    private ItemSO _itemSORef;
    private Image _imageRef;
    private string _combinesWith;
    private ItemSO _combinesInto;
    private Sprite _unselectedSprite;
    private Sprite _selectedSprite;

    public ItemSO ItemSORef { get => _itemSORef; private set => _itemSORef = value; }

    public void InitializeItemIcon(ItemSO itemSORef)
    {
        _imageRef = GetComponent<Image>();
        ItemSORef = itemSORef;
        _imageRef.sprite = itemSORef.ItemUnselected;
        _unselectedSprite = itemSORef.ItemUnselected;
        _selectedSprite = itemSORef.ItemSelected;
        if(itemSORef.CombinesWith != null && itemSORef.CombinesInto)
        {
            _combinesWith = itemSORef.CombinesWith;
            _combinesInto = itemSORef.CombinesInto;
        }        
        ItemSORef.ItemIcon = this;

    }

    public void SelectItem()
    {
        // Checks if the new item that is pressed is combinable with the currently selected item
        if (_combinesWith != null && PlayerInventory.Instance.SelectedItem != null
             && _combinesWith == PlayerInventory.Instance.SelectedItem.name)
        {
            _combinesInto.AddItemToInventory();
            PlayerInventory.Instance.SelectedItem.RemoveItemFromInventory();
            ItemSORef.RemoveItemFromInventory();
        }
        else
        {
            // if another item is selected right now, unselect it
            if (PlayerInventory.Instance.SelectedItem != null)
            {
                PlayerInventory.Instance.SelectedItem.ItemIcon.UnSelectItem();
            }
            //make this the selected item
            PlayerInventory.Instance.SelectedItem = ItemSORef;
            _imageRef.sprite = _selectedSprite;

            AttachToCursor();
        }
        
        
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
        //Cursor.visible = false;
    }

    private void DettachToCursor()
    {
        PlayerInventory.Instance.SelectedItemCursor.gameObject.SetActive(false);
        //Cursor.visible = true;
    }
}
