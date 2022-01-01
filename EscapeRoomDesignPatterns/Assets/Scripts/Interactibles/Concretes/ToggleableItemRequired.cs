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
        if (ConditionCheck())
        {
            _offStateObject.SetActive(false);
            _onStateObject.SetActive(true);

        }
    }

    private bool ConditionCheck()
    {
        if( _itemUsed == true)
        {
            return true;
        }
        else if( PlayerInventory.Instance.SelectedItem != null && PlayerInventory.Instance.SelectedItem.name.Equals(_requiredItemName) )
        {
            UnlockItemFunctionality();
            return true;
        }
        return false;
    }

    private void UnlockItemFunctionality()
    {
        if (PlayerInventory.Instance.SelectedItem != null && PlayerInventory.Instance.SelectedItem.name.Equals(_requiredItemName))
        {
            PlayerInventory.Instance.SelectedItem.RemoveItemFromInventory();
            _itemUsed = true;
        }
    }

}
