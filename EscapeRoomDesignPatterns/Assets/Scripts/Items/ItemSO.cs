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

    [SerializeField] public GameObject _instatiatedUIForItem;

    [SerializeField] private string _combinesWith;

    [SerializeField] private ItemSO _combinesInto;

    public string CombinesWith { get => _combinesWith; }
    public ItemSO CombinesInto { get => _combinesInto; }

    public void AddItemToInventory()
    {
        PlayerInventory.Instance.Inventory.Add(this);

        _instatiatedUIForItem = Instantiate(_itemIconPrefab, UIManager.Instance.InventoryContainer.transform);
        
        ItemIcon = _instatiatedUIForItem.GetComponent<ItemIcon>();

        ItemIcon.InitializeItemIcon(this);
    }

    public void RemoveItemFromInventory()
    {
        if(PlayerInventory.Instance.SelectedItem == this)
        {
            ItemIcon.UnSelectItem();
        }        
        PlayerInventory.Instance.Inventory.Remove(this);
        _instatiatedUIForItem.SetActive(false);
    }
}
