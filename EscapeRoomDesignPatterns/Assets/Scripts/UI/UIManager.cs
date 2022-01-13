using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] public GameObject InventoryContainer;

    [SerializeField] private ItemTooltip _itemTooltip;

    public ItemTooltip ItemTooltip { get => _itemTooltip; set => _itemTooltip = value; }
}
