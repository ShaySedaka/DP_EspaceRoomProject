using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combanieable : Interactible
{
    [SerializeField] private string _itemToCombineWith;

    [SerializeField] private ItemSO _itemCombo;

    public override void Interact()
    {
        if(GameManager.Instance.Player.PlayerInventory.SelectedItem.name.Equals(_itemToCombineWith))
        {
            GameManager.Instance.Player.PlayerInventory.SelectedItem.RemoveItemFromInventory();
            RemoveThisItem();
        }

        _itemCombo.AddItemToInventory();
    }

    private void RemoveThisItem()
    {
        gameObject.GetComponent<ItemIcon>().ItemSORef.RemoveItemFromInventory();
    }
}
