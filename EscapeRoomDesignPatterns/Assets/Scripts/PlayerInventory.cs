using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Singleton<PlayerInventory>
{
    public HashSet<ItemSO> Inventory = new HashSet<ItemSO>();

    private ItemSO _selectedItem;

    public ItemSO SelectedItem { get => _selectedItem; set => _selectedItem = value; }

    private void Update()
    {
        if(Input.GetMouseButton(1) && SelectedItem != null)
        {
            SelectedItem.ItemIcon.UnSelectItem();
        }
    }

}
