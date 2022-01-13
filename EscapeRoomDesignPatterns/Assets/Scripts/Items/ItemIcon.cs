using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ItemIcon : MonoBehaviour, IPointerClickHandler
{
    
    private ItemSO _itemSORef;
    private Image _imageRef;
    private Sprite _unselectedSprite;
    private Sprite _selectedSprite;

    [SerializeField] private UnityEvent _onLeftClick;
    [SerializeField] private UnityEvent _onRightClick;

    public ItemSO ItemSORef { get => _itemSORef; private set => _itemSORef = value; }

    public void ActivateItemDescription()
    {
        UIManager.Instance.ItemTooltip.gameObject.SetActive(true);
        UIManager.Instance.ItemTooltip.InitializeItemToolTip(_itemSORef);
    }

    public void InitializeItemIcon(ItemSO itemSORef)
    {
        _imageRef = GetComponent<Image>();
        ItemSORef = itemSORef;
        _imageRef.sprite = itemSORef.ItemUnselected;
        _unselectedSprite = itemSORef.ItemUnselected;
        _selectedSprite = itemSORef.ItemSelected;
        ItemSORef.ItemIcon = this;

    }

    public void SelectItem()
    {
        // Checks if the new item that is pressed is combinable with the currently selected item
        if (ItemSORef.CombinesWith != null && GameManager.Instance.Player.PlayerInventory.SelectedItem != null
             && ItemSORef.CombinesWith == GameManager.Instance.Player.PlayerInventory.SelectedItem.name)
        {
            ItemSORef.CombinesInto.AddItemToInventory();
            GameManager.Instance.Player.PlayerInventory.SelectedItem.RemoveItemFromInventory();
            ItemSORef.RemoveItemFromInventory();
        }
        else
        {
            // if another item is selected right now, unselect it
            if (GameManager.Instance.Player.PlayerInventory.SelectedItem != null)
            {
                GameManager.Instance.Player.PlayerInventory.SelectedItem.ItemIcon.UnSelectItem();
            }
            //make this the selected item
            GameManager.Instance.Player.PlayerInventory.SelectedItem = ItemSORef;
            _imageRef.sprite = _selectedSprite;

            AttachToCursor();
        }
        
        
    }

    public void UnSelectItem()
    {
        _imageRef.sprite = _unselectedSprite;
        GameManager.Instance.Player.PlayerInventory.SelectedItem = null;

        DettachFromCursor();
    }

    private void AttachToCursor()
    {
        GameManager.Instance.Player.PlayerInventory.SelectedItemCursor.sprite = _unselectedSprite;
        GameManager.Instance.Player.PlayerInventory.SelectedItemCursor.gameObject.SetActive(true);
        //Cursor.visible = false;
    }

    private void DettachFromCursor()
    {
        GameManager.Instance.Player.PlayerInventory.SelectedItemCursor.gameObject.SetActive(false);
        //Cursor.visible = true;
    }

    

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            _onLeftClick.Invoke();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            _onRightClick.Invoke();
        }
    }
}

