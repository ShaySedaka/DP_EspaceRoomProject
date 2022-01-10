using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToggleableItemRequired : Toggleable
{
    [SerializeField] string _requiredItemName;

    private bool _itemUsed = false;

    public override void Interact()
    {
        if (CurrentToggleState == ToggleState.ON)
        {
            ToggleOFF();
            CurrentToggleState = ToggleState.OFF;
        }
        else
        {
            if (ShouldToggleOn())
            {
                ToggleON();
                CurrentToggleState = ToggleState.ON;
            }
        }
    }

    private bool ShouldToggleOn()
    {
        if( _itemUsed == true)
        {
            return true;
        }
        else if( GameManager.Instance.Player.PlayerInventory.SelectedItem != null &&
                 GameManager.Instance.Player.PlayerInventory.SelectedItem.name.Equals(_requiredItemName) )
        {
            UnlockItemFunctionality();
            return true;
        }
        return false;
    }

    protected virtual void UnlockItemFunctionality()
    {
        if ( GameManager.Instance.Player.PlayerInventory.SelectedItem != null &&
             GameManager.Instance.Player.PlayerInventory.SelectedItem.name.Equals(_requiredItemName) )
        {
            GameManager.Instance.Player.PlayerInventory.SelectedItem.RemoveItemFromInventory();
            _itemUsed = true;
        }
    }

}
