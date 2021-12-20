using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemSO", order = 1)]
public class ItemSO : ScriptableObject
{
    [SerializeField] string ItemName;

    [SerializeField] public Sprite ItemUnselected;

    [SerializeField] public Sprite ItemSelected;

    [SerializeField] private GameObject _itemIconPrefab;

    [SerializeField] public ItemIcon ItemIcon;

    public void AddItemToInventory()
    {
        PlayerInventory.Instance.Inventory.Add(this);

        GameObject newItemIconGO = Instantiate(_itemIconPrefab, UIManager.Instance.InventoryContainer.transform);

        ItemIcon = newItemIconGO.GetComponent<ItemIcon>();

        ItemIcon.InitializeItemIcon(this);
    }
}
