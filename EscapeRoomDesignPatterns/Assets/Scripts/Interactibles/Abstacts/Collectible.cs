using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Interactible
{
    [SerializeField] private ItemSO _item;

    public override void Interact()
    {
        _item.AddItemToInventory();
        gameObject.SetActive(false);
    }
}
