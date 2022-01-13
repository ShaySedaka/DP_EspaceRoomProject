using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemSO", order = 1)]
public class ItemSO : ScriptableObject
{
    private GameObject _instatiatedUIForItem;

    [SerializeField] public string ItemName;

    [SerializeField] public Sprite ItemUnselected;

    [SerializeField] public Sprite ItemSelected;

    [SerializeField] private GameObject _itemIconPrefab;

    [SerializeField] public ItemIcon ItemIcon;


    [SerializeField] public string CombinesWith;

    [SerializeField] public ItemSO CombinesInto;

    [SerializeField] public string Description;

    public void AddItemToInventory()
    {
        GameManager.Instance.Player.PlayerInventory.Inventory.Add(this);

        _instatiatedUIForItem = Instantiate(_itemIconPrefab, UIManager.Instance.InventoryContainer.transform);
        
        ItemIcon = _instatiatedUIForItem.GetComponent<ItemIcon>();

        ItemIcon.InitializeItemIcon(this);
    }

    public void RemoveItemFromInventory()
    {
        if(GameManager.Instance.Player.PlayerInventory.SelectedItem == this)
        {
            ItemIcon.UnSelectItem();
        }
        GameManager.Instance.Player.PlayerInventory.Inventory.Remove(this);
        _instatiatedUIForItem.SetActive(false);
    }
}
