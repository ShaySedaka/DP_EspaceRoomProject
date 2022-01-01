using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableItemRequired : Toggleable
{
    [SerializeField] GameObject _offStateObject;
    [SerializeField] GameObject _onStateObject;
    [SerializeField] string _requiredItemName;

    private bool _itemUsed = false;

    protected override void ToggleOFF()
    {
        _offStateObject.SetActive(true);
        _onStateObject.SetActive(false);
    }

    protected override void ToggleON()
    {
        if (ToggleConditionCheck())
        {
            UnlockItemFunctionality();

            _offStateObject.SetActive(false);
            _onStateObject.SetActive(true);

        }
    }

    private bool ToggleConditionCheck()
    {
        if(_itemUsed == true || 
            (PlayerInventory.Instance.SelectedItem != null && PlayerInventory.Instance.SelectedItem.name.Equals(_requiredItemName)) )
        {
            return true;
        }
        return false;
    }

    private void UnlockItemFunctionality()
    {
        if (PlayerInventory.Instance.SelectedItem != null && PlayerInventory.Instance.SelectedItem.name.Equals(_requiredItemName))
        {
            //ItemSO Selected = PlayerInventory.Instance.SelectedItem;
            //Selected.ItemIcon.UnSelectItem();
            //Selected.RemoveItemFromInventory();
            PlayerInventory.Instance.SelectedItem.RemoveItemFromInventory();
            _itemUsed = true;
        }
    }

}
