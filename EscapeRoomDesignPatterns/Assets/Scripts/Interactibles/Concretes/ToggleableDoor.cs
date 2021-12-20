using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableDoor : Toggleable
{
    [SerializeField] GameObject _closedDoor;
    [SerializeField] GameObject _openDoor;
    [SerializeField] string _requiredItemName;


    protected override void ToggleOFF()
    {
        //_closedDoor.SetActive(true);
        //_openDoor.SetActive(false);

        //here will be the code of room transfer
    }

    protected override void ToggleON()
    {
        if (ToggleConditionCheck())
        {
            _closedDoor.SetActive(false);
            _openDoor.SetActive(true);

            OnToggleSuccess();
        }
    }

    private bool ToggleConditionCheck()
    {
        if(PlayerInventory.Instance.SelectedItem != null &&
            PlayerInventory.Instance.SelectedItem.name.Equals(_requiredItemName))
        {
            return true;
        }
        return false;
    }

    private void OnToggleSuccess()
    {
        if (PlayerInventory.Instance.SelectedItem != null)
        {
            ItemSO Selected = PlayerInventory.Instance.SelectedItem;
            Selected.ItemIcon.UnSelectItem();
            Selected.RemoveItemFromInventory();
        }
    }

}
