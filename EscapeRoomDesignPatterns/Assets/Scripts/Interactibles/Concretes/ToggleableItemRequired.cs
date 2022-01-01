using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableItemRequired : Toggleable
{
    [SerializeField] GameObject _offStateObject;
    [SerializeField] GameObject _onStateObject;
    [SerializeField] string _requiredItemName;


    protected override void ToggleOFF()
    {
        _offStateObject.SetActive(true);
        _onStateObject.SetActive(false);
    }

    protected override void ToggleON()
    {
        if (ToggleConditionCheck())
        {
            _offStateObject.SetActive(false);
            _onStateObject.SetActive(true);

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
